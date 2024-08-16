--stored procedures

CREATE PROCEDURE InsertTask
    @Name NVARCHAR(50),
    @Mobile NVARCHAR(20),
    @Email NVARCHAR(30),
    @StateId NVARCHAR(50),
    @CityId NVARCHAR(50)
AS
BEGIN
    INSERT INTO tb_task5 (Name, Mobile, Email, StateId, CityId)
    VALUES (@Name, @Mobile, @Email, @StateId, @CityId);
END
--update stored procedure
CREATE PROCEDURE UpdateTask
    @Id INT,
    @Name NVARCHAR(50),
    @Mobile NVARCHAR(20),
    @Email NVARCHAR(30),
    @StateId NVARCHAR(50),
    @CityId NVARCHAR(50)
AS
BEGIN
    UPDATE tb_task5
    SET 
        Name = @Name,
        Mobile = @Mobile,
        Email = @Email,
        StateId = @StateId,
        CityId = @CityId
    WHERE Id = @Id;
END
---delete stored procedure

CREATE PROCEDURE DeleteTask
    @Id INT
AS
BEGIN
    DELETE FROM tb_task5
    WHERE Id = @Id;


SELECT * FROM task5city WHERE StateId = 's2'