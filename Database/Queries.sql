--USE NHRMDB;
--USE NH;

-- SELECT * FROM MeasurementRecord;
-- SELECT * FROM DataPointRecord;
-- SELECT * FROM DataPoint;
-- SELECT * FROM Measurement;
GO

DROP VIEW IF EXISTS uniqueDates;
GO

-- Unique Dates
CREATE VIEW UniqueDates AS
SELECT CAST(DateTimeRecorded AS DATE) AS Dates FROM MeASurementRecord
GROUP BY CAST(DateTimeRecorded AS DATE);
GO

-- SELECT * FROM UniqueDates;

-- update only day to be able to do several measurements on the same day
-- update MeasurementRecord
-- SET DateTimeRecorded = dateFROMparts(year(DateTimeRecorded), 
-- month(09), 30);



DROP VIEW IF EXISTS ViewData;
GO


Drop VIEW IF EXISTS ViewTableData;
GO

--------------------------------------------------------------------------------------------------------------------------------
--Gets Patient Measuremnt Data -- created by T.Baird
--------------------------------------------------------------------------------------------------------------------------------
drop VIEW IF EXISTS ViewTableData;
GO
Create view ViewTableData as 
select URNumber, DateRecorded as [DateTimeRecorded] , [1-1] as EcogStatus, [2-1] as BreathLessness, [3-1] as LevelOfPain,
       [4-1] as FluidDrain, [5-1] as Mobility, [5-2] as SelfCare , [5-3] as UsualActivities , [5-4] as QolPainDiscomfort , [5-5] as AnxietyDepressinon , [5-6] as HealthSlider
from
(   select mr1.urnumber,
            convert(Date, DateTimeRecorded) as DateRecorded,
            concat(dr1.MeasurementID, '-', dr1.DataPointNumber) as DataPoint,
            dr1.Value
    from MeasurementRecord mr1
    inner join DataPointRecord dr1
    on mr1.MeasurementRecordID = dr1.MeasurementRecordID
) mr
pivot(
        sum(mr.Value)
        for datapoint in(
            [1-1],[2-1],[3-1],[4-1],[5-1],[5-2],[5-3],[5-4],[5-5],[5-6]
            )
)  as pivot_table

---------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------


-- To see view columns and data types
-- select schema_name(v.schema_id) as schema_name,
--        object_name(c.object_id) as view_name,
--        c.column_id,
--        c.name as column_name,
--        type_name(user_type_id) as data_type,
--        c.max_length,
--        c.precision
-- from sys.columns c
-- join sys.views v 
--      on v.object_id = c.object_id
-- order by schema_name,
--          view_name,
--          column_id;
GO
-- original view_Alerts
DROP VIEW IF EXISTS view_Alerts;

GO

CREATE VIEW view_Alerts AS

SELECT ta.AlertID AS Identifier, CONCAT(p.FirstName,' ', p.SurName) AS PatientName,
ta.URNumber AS PatientID, tat.Title AS AlertTitle, ta.StaffID, ta.Status, ta.DateTimeRaised, ta.DateTimeActioned
From tbl_Alert AS ta
INNER JOIN Patient AS p on p.URNumber = ta.URNumber
INNER JOIN tbl_AlertType AS tat on tat.AlertTypeID = ta.AlertTypeID;

GO

DROP VIEW IF EXISTS view_Log;

GO

CREATE VIEW view_Log AS

SELECT ta.AlertID,ta.URNumber, tat.Title AS AlertTitle, ta.StaffID, ta.Status AS Proceeding,
cast(ta.DateTimeActioned as date) as [Date],cast(ta.DateTimeActioned as time) as [Time]
From tbl_Alert AS ta
INNER JOIN Patient AS p on p.URNumber = ta.URNumber
INNER JOIN tbl_AlertType AS tat on tat.AlertTypeID = ta.AlertTypeID
WHERE ta.DateTimeActioned is not null;