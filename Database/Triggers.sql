-- DROP VIEW IF EXISTS view_DataValuesAlerts;

-- GO

-- CREATE VIEW view_DataValuesAlerts
-- AS
-- SELECT dp.DataPointNumber, mr.URNumber,dr.Value,mr.DateTimeRecorded AS DateTimeRaised, mr.MeasurementID, m.MeasurementName, m.Frequency
-- FROM DataPointRecord AS dr
-- INNER JOIN MeasurementRecord AS mr ON dr.MeasurementRecordID = mr.MeasurementRecordID
-- INNER JOIN Measurement AS m ON m.MeasurementID = dr.MeasurementID
-- INNER JOIN DataPoint AS dp ON dp.MeasurementID = dr.MeasurementID; 


DROP PROCEDURE IF EXISTS FluidTrigger;
GO
--procedure if fluid 
CREATE PROCEDURE FluidTrigger
@insertedValue int, @URNumber nvarchar(50), @DateTimeRaised datetime
AS
BEGIN
DECLARE @numberOfRecords int

	-- count number of values returned assign to variable
	SELECT @numberOfRecords
	= Count(*)
	from (
	--get the two latest measurements of fluid drainage
	select TOP 3 dr.Value from DataPointRecord as dr
	inner join MeasurementRecord as mr on dr.MeasurementRecordID = mr.MeasurementRecordID
	where dr.MeasurementID = 4 and mr.URNumber = @URNumber
	order by mr.DateTimeRecorded desc
	) as t
	--from that list get all values greater than 300
	where t.Value > 300;

	--IF fluid levels where greater than 300 the past two times 
	--(plus this current insert which it is because this stored procedure is running)
	IF (@numberOfRecords) = 3
	--INSERT an alert into the alert table
	BEGIN
		DECLARE @StaffID int;
		DECLARE @AlertTypeID int;

		SELECT @StaffID = 1;
		SELECT @AlertTypeID = 1;

		INSERT INTO tbl_Alert
		(
			URNumber,
			StaffID,
			AlertTypeID,
			TriggerValue,
			DateTimeRaised
		)

		VALUES(@URNumber,@StaffID,@AlertTypeID,@insertedValue,@DateTimeRaised)
	END
END

GO 

DROP PROCEDURE IF EXISTS PainTrigger;
GO
--procedure if level of pain is greater than or equal to 4 three times in a row 
CREATE PROCEDURE PainTrigger
@insertedValue int, @URNumber nvarchar(50), @DateTimeRaised datetime
AS
BEGIN
DECLARE @numberOfRecords int

	-- count number of values returned assign to variable
	SELECT @numberOfRecords
	= Count(*)
	from (
	--get the three latest measurements of pain for the patient
	select TOP 3 dr.Value from DataPointRecord as dr
	inner join MeasurementRecord as mr on dr.MeasurementRecordID = mr.MeasurementRecordID
	where dr.MeasurementID = 3 and mr.URNumber = @URNumber
	order by mr.DateTimeRecorded desc
	) as t
	--from that list get all values greater than 4
	where t.Value >= 4;

	--IF pain levels where greater than 4 the past three times 	
	IF (@numberOfRecords) = 3
	--INSERT an alert into the alert table
	BEGIN
		DECLARE @StaffID int;
		DECLARE @AlertTypeID int;

		SELECT @StaffID = 1;
		SELECT @AlertTypeID = 3;

		INSERT INTO tbl_Alert
		(
			URNumber,
			StaffID,
			AlertTypeID,
			TriggerValue,
			DateTimeRaised
		)

		VALUES(@URNumber,@StaffID,@AlertTypeID,@insertedValue,@DateTimeRaised)
	END
END

GO 

DROP PROCEDURE IF EXISTS BreathlessnessTrigger;
GO
--procedure if level of pain is greater than or equal to 4 three times in a row 
CREATE PROCEDURE BreathlessnessTrigger
@insertedValue int, @URNumber nvarchar(50), @DateTimeRaised datetime
AS
BEGIN
DECLARE @numberOfRecords int

	-- count number of values returned assign to variable
	SELECT @numberOfRecords
	= Count(*)
	from (
	--get the three latest measurements of pain for the patient
	select TOP 3 dr.Value from DataPointRecord as dr
	inner join MeasurementRecord as mr on dr.MeasurementRecordID = mr.MeasurementRecordID
	where dr.MeasurementID = 2 and mr.URNumber = @URNumber
	order by mr.DateTimeRecorded desc
	) as t
	--from that list get all values greater than 4
	where t.Value >= 4;

	--IF pain levels where greater than 4 the past three times 	
	IF (@numberOfRecords) = 3
	--INSERT an alert into the alert table
	BEGIN
		DECLARE @StaffID int;
		DECLARE @AlertTypeID int;

		SELECT @StaffID = 1;
		SELECT @AlertTypeID = 4;

		INSERT INTO tbl_Alert
		(
			URNumber,
			StaffID,
			AlertTypeID,
			TriggerValue,
			DateTimeRaised
		)

		VALUES(@URNumber,@StaffID,@AlertTypeID,@insertedValue,@DateTimeRaised)
	END
END

GO 

DROP TRIGGER IF EXISTS trg_InsertAlerts;

GO

CREATE TRIGGER trg_InsertAlerts ON DataPointRecord
	AFTER INSERT
AS 
BEGIN

	DECLARE @URNumber nvarchar(50);
	DECLARE @StaffID int;
	DECLARE @AlertTypeID int;
	DECLARE @TriggerValue int;
	DECLARE @DateTimeRaised datetime;

	-- check if alert is above value threshold and measurement ID is fluid drainage
	IF  (SELECT Value FROM inserted) > 300 AND (SELECT MeasurementID FROM inserted) = 4
		BEGIN
			SELECT @URNumber = URNumber FROM MeasurementRecord WHERE MeasurementRecordID = (SELECT MeasurementRecordId FROM inserted);
			SELECT @StaffID = 1;
			SELECT @AlertTypeID = 1;
			SELECT @TriggerValue = value FROM inserted;
			SELECT @DateTimeRaised = DateTimeRecorded FROM MeasurementRecord WHERE MeasurementRecordID = (SELECT MeasurementRecordId FROM inserted);

			EXEC FluidTrigger @insertedValue = @TriggerValue, @URNumber = @URNumber, @DateTimeRaised = @DateTimeRaised
		END

		-- check if alert is above value threshold and measurement ID is level of pain
		IF  (SELECT Value FROM inserted) >= 4 AND (SELECT MeasurementID FROM inserted) = 3
		BEGIN				
			SELECT @URNumber = URNumber FROM MeasurementRecord WHERE MeasurementRecordID = (SELECT MeasurementRecordId FROM inserted);
			SELECT @StaffID = 1;
			SELECT @AlertTypeID = 1;
			SELECT @TriggerValue = value FROM inserted;
			SELECT @DateTimeRaised = DateTimeRecorded FROM MeasurementRecord WHERE MeasurementRecordID = (SELECT MeasurementRecordId FROM inserted);

			EXEC PainTrigger @TriggerValue, @URNumber = @URNumber, @DateTimeRaised = @DateTimeRaised
		END

		IF  (SELECT Value FROM inserted) >= 4 AND (SELECT MeasurementID FROM inserted) = 2
		BEGIN
			SELECT @URNumber = URNumber FROM MeasurementRecord WHERE MeasurementRecordID = (SELECT MeasurementRecordId FROM inserted);
			SELECT @StaffID = 1;
			SELECT @AlertTypeID = 1;
			SELECT @TriggerValue = value FROM inserted;
			SELECT @DateTimeRaised = DateTimeRecorded FROM MeasurementRecord WHERE MeasurementRecordID = (SELECT MeasurementRecordId FROM inserted);

			EXEC BreathlessnessTrigger @TriggerValue, @URNumber = @URNumber, @DateTimeRaised = @DateTimeRaised

		END
END
	GO

-- Latest Measurements
-- SELECT mr.MeasurementRecordID, mr.DateTimeRecorded, mr.MeasurementID, mr.CategoryID, mr.URNumber, pm.Frequency
-- FROM MeasurementRecord AS mr
-- INNER JOIN PatientMeasurement AS pm ON pm.MeasurementID = mr.MeasurementID AND pm.URNumber = mr.URNumber AND mr.CategoryID = pm.CategoryID
-- WHERE mr.DateTimeRecorded = (SELECT max(mr2.DateTimeRecorded)
-- 							FROM MeasurementRecord mr2
-- 							where mr2.MeasurementID = mr.MeasurementID
-- 							);

--USE [NHOriginalDB]
--GO

--INSERT INTO [dbo].[MeasurementRecord]
--           ([DateTimeRecorded]
--           ,[MeasurementID]
--           ,[CategoryID]
--           ,[URNumber])
--     VALUES
--           ('2025-01-10'
--           ,4
--           ,1
--           ,123456789)
--GO

--select * from MeasurementRecord

--SELECT * FROM DataPointRecord;

--delete from DataPointRecord where MeasurementRecordID = 58;

--delete from MeasurementRecord where MeasurementRecordID = 58;


--USE [NHOriginalDB]
--GO

--INSERT INTO [dbo].[DataPointRecord]
--           ([MeasurementID]
--           ,[DataPointNumber]
--           ,[Value]
--           ,[MeasurementRecordID])
--     VALUES
--           (4
--           ,1
--           ,305
--           ,59)
--GO

--select * from tbl_Alert;
--select * from [DataPointRecord];
--SELECT * FROM MeasurementRecord;
--select * from view_DataValuesALERTS where MeasurementID = 4;