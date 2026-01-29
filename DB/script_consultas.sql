--SCRIPT CONSULTAS SOLICITADAS

SELECT t.Id, t.Name, t.creationDate, s.Name as StatusName,
(u.FirstName + ' ' + u.LastName) as UserName, u.Email
FROM Tasks t
INNER JOIN Statuses s on s.Id = t.statusId
INNER JOIN Users u on u.Id = t.userId;

SELECT t.Id, t.Name, t.creationDate, s.Name as StatusName,
(u.FirstName + ' ' + u.LastName) as UserName, u.Email
FROM Tasks t
INNER JOIN Statuses s on s.Id = t.statusId
INNER JOIN Users u on u.Id = t.userId
WHERE s.Name = 'Pending';


SELECT t.Id, t.Name, t.creationDate, s.Name as StatusName,
(u.FirstName + ' ' + u.LastName) as UserName, u.Email
FROM Tasks t
INNER JOIN Statuses s on s.Id = t.statusId
INNER JOIN Users u on u.Id = t.userId
ORDER BY t.CreationDate 