CREATE TABLE users
(
id INT PRIMARY KEY IDENTITY(1,1),
email VARCHAR(MAX) NULL,
password VARCHAR(MAX) NULL,
date DATE NULL
)
select * from users