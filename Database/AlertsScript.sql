DROP VIEW IF EXISTS view_Alerts;
DROP TABLE IF EXISTS tbl_Alert;
DROP TABLE IF EXISTS tbl_AlertType;


CREATE TABLE tbl_AlertType(
	AlertTypeID INT IDENTITY(1,1) NOT NULL,
	Title NVARCHAR(500) NOT NULL,
	Details NVARCHAR(600) NOT NULL,
	TriggerCondition NVARCHAR(400) NOT NULL,
	TriggerThresholdValue INT NOT NULL,
	CONSTRAINT PK_AlertTypeID PRIMARY KEY (AlertTypeID)
)
	
INSERT INTO tbl_AlertType (Title , Details , TriggerCondition, TriggerThresholdValue) values
('High Fluid Drain', 'The Patiients IPC drains greater than the threshold amouunt', 'IPC_Drainage >', 300),
('Quality of Life', 'Alert to fire when patient records a QOL reading of <= 2 for (first time after recording higher qol readeings previously)', 'QOL <=', 2 );



CREATE TABLE tbl_Alert(
	AlertID INT IDENTITY(1,1) NOT NULL,
	[URNumber] NVARCHAR(50) NOT NULL,
	StaffID INT NOT NULL,
	AlertTypeID INT NOT NULL,
	TriggerValue INT NOT NULL,
	DateTimeRaised DATETIME NOT NULL,
	DateTimeActioned DATETIME,
	Status NVARCHAR(15),
	Notes NVARCHAR(300),
	CONSTRAINT PK_AlertID  PRIMARY KEY (AlertID),
	CONSTRAINT FK_URNumber FOREIGN KEY (URNumber) REFERENCES Patient,
	CONSTRAINT FK_StaffID FOREIGN KEY (StaffID) REFERENCES Staff,
	CONSTRAINT FK_AlertTypeID  FOREIGN KEY (AlertTypeID) REFERENCES tbl_AlertType,
	CONSTRAINT CHK_Status CHECK (Status = 'Actioned' OR Status = 'Snooze' OR Status = 'Dismiss')
)

INSERT INTO tbl_Alert (URNumber, StaffID, AlertTypeID, TriggerValue, DateTimeRaised, DateTimeActioned, [Status], Notes)
VALUES ('1',  1,    1,     320 ,   '2021-10-13 08:50:12',    null, 'Actioned', null),
('1',  1,    1,      320 ,  '2015-10-13 08:50:12', '2021-10-13 08:53:10', null , null);


GO

CREATE VIEW view_Alerts AS

SELECT ta.AlertID AS Identifier, CONCAT(p.FirstName,' ', p.SurName) AS PatientName,
ta.URNumber AS PatientID, tat.Title AS AlertTitle, ta.StaffID, ta.Status, ta.DateTimeRaised, ta.DateTimeActioned
From tbl_Alert AS ta
INNER JOIN Patient AS p on p.URNumber = ta.URNumber
INNER JOIN tbl_AlertType AS tat on tat.AlertTypeID = ta.AlertTypeID;