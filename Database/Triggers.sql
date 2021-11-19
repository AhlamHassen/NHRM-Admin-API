-- DROP VIEW IF EXISTS view_DataValuesAlerts;

-- GO

-- CREATE VIEW view_DataValuesAlerts
-- AS
-- SELECT dp.DataPointNumber, mr.URNumber,dr.Value,mr.DateTimeRecorded AS DateTimeRaised, mr.MeasurementID, m.MeasurementName, m.Frequency
-- FROM DataPointRecord AS dr
-- INNER JOIN MeasurementRecord AS mr ON dr.MeasurementRecordID = mr.MeasurementRecordID
-- INNER JOIN Measurement AS m ON m.MeasurementID = dr.MeasurementID
-- INNER JOIN DataPoint AS dp ON dp.MeasurementID = dr.MeasurementID; 


USE NH;

DROP PROCEDURE IF EXISTS FluidTrigger;
GO
--procedure if fluid 
CREATE PROCEDURE FluidTrigger
	@insertedValue int,
	@URNumber nvarchar(50),
	@DateTimeRaised datetime
AS
BEGIN
	DECLARE @numberOfRecords int

	-- count number of values returned assign to variable
	SELECT @numberOfRecords
	= Count(*)
	from (
	--get the two latest measurements of fluid drainage
	select TOP 3
			dr.Value
		from DataPointRecord as dr
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

		SELECT @StaffID = null;
		SELECT @AlertTypeID = 1;

		INSERT INTO tbl_Alert
			(
			URNumber,
			StaffID,
			AlertTypeID,
			TriggerValue,
			DateTimeRaised
			)

		VALUES(@URNumber, @StaffID, @AlertTypeID, @insertedValue, @DateTimeRaised)
	END
END

GO

DROP PROCEDURE IF EXISTS PainTrigger;
GO
--procedure if level of pain is greater than or equal to 4 three times in a row 
CREATE PROCEDURE PainTrigger
	@insertedValue int,
	@URNumber nvarchar(50),
	@DateTimeRaised datetime
AS
BEGIN
	DECLARE @numberOfRecords int

	-- count number of values returned assign to variable
	SELECT @numberOfRecords
	= Count(*)
	from (
	--get the three latest measurements of pain for the patient
	select TOP 3
			dr.Value
		from DataPointRecord as dr
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

		SELECT @StaffID = null;
		SELECT @AlertTypeID = 3;

		INSERT INTO tbl_Alert
			(
			URNumber,
			StaffID,
			AlertTypeID,
			TriggerValue,
			DateTimeRaised
			)

		VALUES(@URNumber, @StaffID, @AlertTypeID, @insertedValue, @DateTimeRaised)
	END
END

GO

DROP PROCEDURE IF EXISTS BreathlessnessTrigger;
GO

CREATE PROCEDURE BreathlessnessTrigger
	@insertedValue int,
	@URNumber nvarchar(50),
	@DateTimeRaised datetime
AS
BEGIN
	DECLARE @numberOfRecords int

	-- count number of values returned assign to variable
	SELECT @numberOfRecords
	= Count(*)
	from (
	--get the three latest measurements of pain for the patient
	select TOP 3
			dr.Value
		from DataPointRecord as dr
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

		SELECT @StaffID = null;
		SELECT @AlertTypeID = 4;

		INSERT INTO tbl_Alert
			(
			URNumber,
			StaffID,
			AlertTypeID,
			TriggerValue,
			DateTimeRaised
			)

		VALUES(@URNumber, @StaffID, @AlertTypeID, @insertedValue, @DateTimeRaised)
	END
END

GO

--QOL PROCEDURE
DROP PROCEDURE IF EXISTS QOLTriggerConsec;
 
 GO

CREATE PROCEDURE QOLTriggerConsec
	@insertedValue int,
	@URNumber nvarchar(50),
	@DateTimeRaised datetime
AS
BEGIN
	DECLARE @numberOfRecords int

	-- count number of values returned assign to variable
	SELECT @numberOfRecords
 	= Count(*)
	from (
 	--get the three latest measurements of pain for the patient
 	SELECT TOP 18
			dpr.MeasurementID, dpr.DataPointNumber, dpr.Value, dpr.MeasurementRecordID, mr.DateTimeRecorded, mr.URNumber
		FROM DataPointRecord as dpr
			INNER JOIN MeasurementRecord as mr ON mr.MeasurementRecordID = dpr.MeasurementRecordID
		WHERE dpr.MeasurementID = 5 AND mr.URNumber = @URNumber
		ORDER BY mr.DateTimeRecorded DESC
 	) as t
	--from that list get all values greater than 4
	WHERE (
	t.DataPointNumber IN (1,2,3) and t.Value <=3)
		OR (t.DataPointNumber IN (4,5) AND t.Value >= 4)
		OR (t.DataPointNumber IN (6) AND t.Value <= 20);

	print(@numberOfRecords)
	--IF pain levels where greater than 4 the past three times 	
	IF (@numberOfRecords) = 18
 	--INSERT an alert into the alert table
 	BEGIN
		DECLARE @StaffID int;
		DECLARE @AlertTypeID int;

		SELECT @StaffID = null;
		SELECT @AlertTypeID = 2;

		INSERT INTO tbl_Alert
			(
			URNumber,
			StaffID,
			AlertTypeID,
			TriggerValue,
			DateTimeRaised
			)

		VALUES(@URNumber, @StaffID, @AlertTypeID, @insertedValue, @DateTimeRaised)
	END
END

GO

DROP PROCEDURE IF EXISTS QOLTriggerVeryPoor;

GO

CREATE PROCEDURE QOLTriggerVeryPoor
	@insertedValue int,
	@URNumber nvarchar(50),
	@DateTimeRaised datetime
AS
BEGIN
	DECLARE @StaffID int;
	DECLARE @AlertTypeID int;

	SELECT @StaffID = null;
	SELECT @AlertTypeID = 5;

	INSERT INTO tbl_Alert
		(
		URNumber,
		StaffID,
		AlertTypeID,
		TriggerValue,
		DateTimeRaised
		)
	VALUES(@URNumber, @StaffID, @AlertTypeID, @insertedValue, @DateTimeRaised)
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
	IF  (SELECT TOP 1
			Value
		FROM inserted) > 300 AND (SELECT TOP 1
			MeasurementID
		FROM inserted) = 4
		BEGIN
		SELECT @URNumber = URNumber
		FROM MeasurementRecord
		WHERE MeasurementRecordID = (SELECT MeasurementRecordId
		FROM inserted);
		SELECT @StaffID = null;
		SELECT @AlertTypeID = 1;
		SELECT @TriggerValue = value
		FROM inserted;
		SELECT @DateTimeRaised = DateTimeRecorded
		FROM MeasurementRecord
		WHERE MeasurementRecordID = (SELECT MeasurementRecordId
		FROM inserted);

		EXEC FluidTrigger @insertedValue = @TriggerValue, @URNumber = @URNumber, @DateTimeRaised = @DateTimeRaised
	END

	-- check if alert is above value threshold and measurement ID is level of pain
	IF  (SELECT TOP 1
			Value
		FROM inserted) >= 4 AND (SELECT TOP 1
			MeasurementID
		FROM inserted) = 3
		BEGIN
		SELECT @URNumber = URNumber
		FROM MeasurementRecord
		WHERE MeasurementRecordID = (SELECT MeasurementRecordId
		FROM inserted);
		SELECT @StaffID = null;
		SELECT @AlertTypeID = 3;
		SELECT @TriggerValue = value
		FROM inserted;
		SELECT @DateTimeRaised = DateTimeRecorded
		FROM MeasurementRecord
		WHERE MeasurementRecordID = (SELECT MeasurementRecordId
		FROM inserted);

		EXEC PainTrigger @TriggerValue, @URNumber = @URNumber, @DateTimeRaised = @DateTimeRaised
	END

	-- check if alert is above value threshold and measurement ID is Breathlessness
	IF  (SELECT TOP 1
			Value
		FROM inserted) >= 4 AND (SELECT TOP 1
			MeasurementID
		FROM inserted) = 2
		BEGIN
		SELECT @URNumber = URNumber
		FROM MeasurementRecord
		WHERE MeasurementRecordID = (SELECT MeasurementRecordId
		FROM inserted);
		SELECT @StaffID = null;
		SELECT @AlertTypeID = 4;
		SELECT @TriggerValue = value
		FROM inserted;
		SELECT @DateTimeRaised = DateTimeRecorded
		FROM MeasurementRecord
		WHERE MeasurementRecordID = (SELECT MeasurementRecordId
		FROM inserted);

		EXEC BreathlessnessTrigger @TriggerValue, @URNumber = @URNumber, @DateTimeRaised = @DateTimeRaised
	END

	-- check QOL and trigger an alert if required
	IF (
		SELECT COUNT(Value)
	FROM inserted
	WHERE ((DataPointNumber = 1 OR DataPointNumber = 2 OR DataPointNumber = 3) AND Value <= 3)
		OR ((DataPointNumber = 4 OR DataPointNumber = 5) AND Value >= 4)
		OR (DataPointNumber = 6 AND Value <= 20)
		) = 6
		
		BEGIN
		SELECT @URNumber = URNumber
		FROM MeasurementRecord
		WHERE MeasurementRecordID = (SELECT TOP 1
			MeasurementRecordId
		FROM inserted);
		SELECT @StaffID = null;
		SELECT @AlertTypeID = 2;
		SELECT @TriggerValue = value
		FROM inserted;
		SELECT @DateTimeRaised = DateTimeRecorded
		FROM MeasurementRecord
		WHERE MeasurementRecordID = (SELECT TOP 1
			MeasurementRecordId
		FROM inserted);

		EXEC QOLTriggerConsec @TriggerValue, @URNumber = @URNumber, @DateTimeRaised = @DateTimeRaised

	END

	IF (
		SELECT COUNT(Value)
	FROM inserted
	WHERE ((DataPointNumber = 1 OR DataPointNumber = 2 OR DataPointNumber = 3) AND Value = 1)
		OR ((DataPointNumber = 4 OR DataPointNumber = 5) AND Value = 5)
		OR (DataPointNumber = 6 AND Value <= 10)
		) >= 1

		BEGIN
		SELECT @URNumber = URNumber
		FROM MeasurementRecord
		WHERE MeasurementRecordID = (SELECT TOP 1
			MeasurementRecordId
		FROM inserted);
		SELECT @StaffID = null;
		SELECT @AlertTypeID = 5;
		SELECT @TriggerValue = value
		FROM inserted;
		SELECT @DateTimeRaised = DateTimeRecorded
		FROM MeasurementRecord
		WHERE MeasurementRecordID = (SELECT TOP 1
			MeasurementRecordId
		FROM inserted);

		EXEC QOLTriggerVeryPoor @TriggerValue, @URNumber = @URNumber, @DateTimeRaised = @DateTimeRaised

	END
END

GO

--need to change some sqlserver settings for this to work
--todo run procedure daily
--todo surver needs to restart

-- ----------------------------------------------
-- DROP PROCEDURE IF EXISTS procSurveyCheck;
-- GO 
-- --create/alter a stored proceudre  accordingly
-- create procedure procSurveyCheck
-- as 
-- DECLARE @authHeader NVARCHAR(64);
-- DECLARE @contentType NVARCHAR(64);
-- DECLARE @postData NVARCHAR(2000);
-- DECLARE @responseText NVARCHAR(2000);
-- DECLARE @responseXML NVARCHAR(2000);
-- DECLARE @ret INT;
-- DECLARE @status NVARCHAR(32);
-- DECLARE @statusText NVARCHAR(32);
-- DECLARE @token INT;
-- DECLARE @url NVARCHAR(256);
-- DECLARE @Authorization NVARCHAR(200);

-- --set your post params
-- SET @authHeader = '';
-- SET @contentType = 'application/x-www-form-urlencoded';
-- SET @postData = ''
-- SET @url = 'http://localhost:5000/Alerts/SurveyCheck'

-- -- Open the connection.
-- EXEC @ret = sp_OACreate 'MSXML2.ServerXMLHTTP', @token OUT;
-- IF @ret <> 0 RAISERROR('Unable to open HTTP connection.', 10, 1);

-- -- Send the request.
-- EXEC @ret = sp_OAMethod @token, 'open', NULL, 'POST', @url, 'false';
-- --set a custom header Authorization is the header key and VALUE is the value in the header
-- EXEC sp_OAMethod @token, 'SetRequestHeader', NULL, 'Authorization', 'VALUE'

-- EXEC @ret = sp_OAMethod @token, 'setRequestHeader', NULL, 'Authentication', @authHeader;
-- EXEC @ret = sp_OAMethod @token, 'setRequestHeader', NULL, 'Content-type', @contentType;
-- EXEC @ret = sp_OAMethod @token, 'send', NULL, @postData;

-- -- Handle the response.
-- EXEC @ret = sp_OAGetProperty @token, 'status', @status OUT;
-- EXEC @ret = sp_OAGetProperty @token, 'statusText', @statusText OUT;
-- EXEC @ret = sp_OAGetProperty @token, 'responseText', @responseText OUT;

-- -- Show the response.
-- PRINT 'Status: ' + @status + ' (' + @statusText + ')';
-- PRINT 'Response text: ' + @responseText;

-- -- Close the connection.
-- EXEC @ret = sp_OADestroy @token;
-- IF @ret <> 0 RAISERROR('Unable to close HTTP connection.', 10, 1);

-- GO 


-- --Server configuration requirements
-- sp_configure 'show advanced options', 1;  
-- GO  
-- RECONFIGURE;  
-- GO  
-- sp_configure 'Ole Automation Procedures', 1;  
-- GO  
-- RECONFIGURE;  
-- GO  

-- USE Master
-- GO

-- IF  EXISTS( SELECT *
--             FROM sys.objects
--             WHERE object_id = OBJECT_ID(N'[dbo].[MyBackgroundTask]')
--             AND type in (N'P', N'PC'))
--     DROP PROCEDURE [dbo].[MyBackgroundTask]
-- GO

-- --set up time to run in master DB
-- CREATE PROCEDURE MyBackgroundTask
-- AS
-- BEGIN
--     -- SET NOCOUNT ON added to prevent extra result sets from
--     -- interfering with SELECT statements.
--     SET NOCOUNT ON;

--     -- The interval between cleanup attempts
--     declare @timeToRun nvarchar(50)
--     set @timeToRun = '13:45:00'

--     while 1 = 1
--     begin
--         waitfor time @timeToRun
--         begin
--             execute [NHOriginalDB].[dbo].[procSurveyCheck]
--         end
--     end
-- END
-- GO

-- -- Run the procedure when the master database starts.
-- sp_procoption    @ProcName = 'MyBackgroundTask',
--                 @OptionName = 'startup',
--                 @OptionValue = 'on'
-- GO
------------------------------------------------------------------


--insert statement for measurement ID 5 VVV

 --insert into MeasurementRecord (DateTimeRecorded,MeasurementID,CategoryID,URNumber)
 --values ('2023-01-01',5,1,'123456789')

 --select * from MeasurementRecord order by MeasurementRecordID desc;
 --select * from tbl_Alert;
 --select * from Measurement;

 --insert into DataPointRecord (MeasurementID, DataPointNumber, Value,MeasurementRecordID)
 --VALUES 
 --	(5,1,3,38),
 --	(5,2,3,38),
 --	(5,3,3,38),
 --	(5,4,4,38),
 --	(5,5,4,38),
 --	(5,6,20,38)