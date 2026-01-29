--SCRIPTS
--Estas inserciones ya está en la BD actualmente
INSERT INTO Tasks (Name, UserId,StatusId,Duration,CreationDate,AdditionalInfo)
VALUES ('Finish report', 1, 1, 24, GETDATE(), 
'{"Priority": "High", "EndDate": "2026-01-29", "Labels": ["Urgent", "Accounting"], "Metadata": {"Author": "Julian Gómez"}}');

INSERT INTO Tasks (Name, UserId,StatusId,Duration,CreationDate,AdditionalInfo)
VALUES ('Deploy to Production', 2, 1, 8, GETDATE(), 
'{"Priority": "Medium", "EndDate": "2026-01-30", "Labels": ["Urgent", "Infrastructure"], "Metadata": {"Author": "Pedro Sánchez"}}');

INSERT INTO Tasks (Name, UserId,StatusId,Duration,CreationDate,AdditionalInfo)
VALUES ('Testing', 2, 1, 8, GETDATE(), 
'{"Priority": "Low", "EndDate": "2026-01-31", "Labels": ["Not urgent", "Testing"], "Metadata": {"Author": "Luis Ramirez"}}');

SELECT t.Name as 'TaskName', t.Duration,
		JSON_VALUE(t.AdditionalInfo,'$.EndDate') as EndDate,
		JSON_QUERY(t.AdditionalInfo,'$.Labels') as Labels
FROM Tasks t

SELECT * FROM Tasks 
WHERE JSON_VALUE(AdditionalInfo, '$.Priority') = 'Medium';

UPDATE Tasks SET AdditionalInfo = JSON_MODIFY(AdditionalInfo, '$.EndDate', '2026-02-10')
WHERE Id = 10;

SELECT t.Name, m.value AS Metadata
FROM Tasks t
CROSS APPLY OPENJSON(t.AdditionalInfo, '$.Labels') AS m;

