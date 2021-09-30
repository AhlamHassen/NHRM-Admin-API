USE NHRMDB;

SELECT * FROM MeASurementRecord;
SELECT * FROM DataPointRecord;
SELECT * FROM DataPoint;
GO

-- Unique Dates
CREATE VIEW UniqueDates AS
SELECT CAST(DateTimeRecorded AS DATE) AS Dates FROM MeASurementRecord
GROUP BY CAST(DateTimeRecorded AS DATE);
GO

SELECT * FROM UniqueDates;

-- update ONly day to be able to do several meASurements ON the same day
-- update MeasurementRecord
-- SET DateTimeRecorded = dateFROMparts(year(DateTimeRecorded), 
-- mONth(DateTimeRecorded), 28)
-- WHERE DateTimeRecorded = '2021-09-30 13:17:46.003';

SELECT DISTINCT CAST(DateTimeRecorded AS DATE) AS Dates , MeasurementRecordID
FROM MeASurementRecord;
GO

-- View that contains all the data needed for the view table
CREATE VIEW ViewData AS
SELECT L.Dates, N.* FROM
(
    SELECT MeasurementRecordID, CAST(DateTimeRecorded AS DATE) AS Dates
    FROM MeASurementRecord
) L
INNER JOIN
(
    SELECT MeasurementRecordID, MeasurementID, DataPointNumber, [Value] 
    FROM DataPointRecord
)N
ON L.MeasurementRecordID = N.MeasurementRecordID;
GO


SELECT D.Dates AS [Date], E.Ecog AS Ecog, B.Breath AS BreathLessness,
L.LOP AS [Level of Pain], F.Fluid AS [Fluid Drainage], Mo.Mobility AS Mobility,
S.SelfC AS [Self Care], U.UA AS [Usual-Activities], P.Pain AS Pain,
Ad.Anxiety AS Anxiety, Q.QOLV AS [Quality of Life]
FROM
((((((((((
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
ON D.Dates = Q.Dates;