# nTierHotel

CREATE TRIGGER Before_Insert_People ON People
INSTEAD OF INSERT
AS
DECLARE @civilizationNo nchar(11)=(SELECT CivilizationNo FROM inserted)
DECLARE @firstName nvarchar(150)=(SELECT FirstName FROM inserted)
DECLARE @lastName nvarchar(150)=(SELECT LastName FROM inserted)
DECLARE @civNoToComp nchar(11)=(SELECT CivilizationNo FROM People WHERE CivilizationNo=@civilizationNo)
DECLARE @personName nvarchar(150)=(SELECT FirstName From People WHERE FirstName=@firstName AND CivilizationNo=@civilizationNo)


BEGIN

	IF @civNoToComp IS NOT NULL
		BEGIN
			IF @personName IS NOT NULL
				BEGIN
					ROLLBACK TRANSACTION;
				END
			ELSE
				BEGIN
					RAISERROR('Bu Kimlik NO ile uyuşan isim bulunmamaktadır',11,1)
					ROLLBACK TRANSACTION;
				END
		END
	ELSE
		BEGIN
			INSERT INTO People VALUES (@civilizationNo,@firstName,@lastName)
		END

END
