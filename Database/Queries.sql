USE NHRMDB;

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

-- View that contains all the data needed for the view table
CREATE VIEW ViewData AS
SELECT L.URNumber, L.Dates, N.* FROM
(
    SELECT URNumber, MeasurementRecordID, CAST(DateTimeRecorded AS DATE) AS Dates
    FROM MeASurementRecord
) L
INNER JOIN
(
    SELECT MeasurementRecordID, MeasurementID, DataPointNumber, [Value] 
    FROM DataPointRecord
)N
ON L.MeasurementRecordID = N.MeasurementRecordID;
GO


Drop VIEW IF EXISTS ViewTableData;
GO

-- Includes all the data we need for the view patient table
CREATE VIEW ViewTableData AS
SELECT UR.URNumber as URNumber ,D.Dates AS [DateTimeRecorded], E.Ecog AS EcogStatus, B.Breath AS BreathLessness,
L.LOP AS LevelOfPain, F.Fluid AS FluidDrain, Mo.Mobility AS Mobility,
S.SelfC AS SelfCare, U.UA AS UsualActivities, P.Pain AS QolPainDiscomfort,
Ad.Anxiety AS AnxietyDepressinon, Q.QOLV AS HealthSlider
FROM
(((((((((((
    SELECT DISTINCT Dates FROM ViewData
)D
LEFT JOIN
(
    SELECT Dates, [Value] AS Ecog FROM ViewData
    WHERE MeasurementID = 1 AND DataPointNumber=1
) E
ON D.Dates = E.Dates)
LEFT JOIN
(
    SELECT Dates, [Value] AS Breath FROM ViewData
    WHERE MeasurementID = 2 AND DataPointNumber=1
) B
ON D.Dates = B.Dates)
LEFT JOIN
(
    SELECT Dates, [Value] AS LOP FROM ViewData
    WHERE MeasurementID = 3 AND DataPointNumber=1
) L
ON D.Dates = L.Dates)
LEFT JOIN
(
    SELECT Dates, [Value] AS Fluid FROM ViewData
    WHERE MeasurementID = 4 AND DataPointNumber=1
)F
ON D.Dates = F.Dates)
LEFT JOIN
(
    SELECT Dates, [Value] AS Mobility FROM ViewData
    WHERE MeasurementID = 5 AND DataPointNumber=1
)Mo
ON D.Dates = Mo.Dates)
LEFT JOIN
(
    SELECT Dates, [Value] AS SelfC FROM ViewData
    WHERE MeasurementID = 5 AND DataPointNumber=2
)S
ON D.Dates = S.Dates)
LEFT JOIN
(
    SELECT Dates, [Value] AS UA FROM ViewData
    WHERE MeasurementID = 5 AND DataPointNumber=3  
)U
ON D.Dates = U.Dates)
LEFT JOIN
(
    SELECT Dates, [Value] AS Pain FROM ViewData
    WHERE MeasurementID = 5 AND DataPointNumber=4 
)P
ON D.Dates = P.Dates)
LEFT JOIN
(
    SELECT Dates, [Value] AS Anxiety FROM ViewData
    WHERE MeasurementID = 5 AND DataPointNumber=5
)AD
ON D.Dates = AD.Dates)
LEFT JOIN
(
    SELECT Dates, [Value] AS QOLV FROM ViewData
    WHERE MeasurementID = 5 AND DataPointNumber=6
)Q
ON D.Dates = Q.Dates)
LEFT JOIN
(
    SELECT Distinct URNumber, Dates FROM ViewData
) UR
ON D.dates = UR.Dates;
GO


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
