CREATE PROCEDURE [dbo].[Kaydet] (
@uniAdi NVARCHAR(200) = NULL,
@fakAdi NVARCHAR(200) = NULL,
@bolAdi NVARCHAR(200) = NULL,
@il NVARCHAR(20) = NULL,
@bolumKodu NVARCHAR(20) = NULL,
@puanTuru NVARCHAR(10) = NULL,
@kontenjan INT,
@yerlesen INT,
@enKucukPuan REAL,
@enYuksekPuan REAL,
@oEnKucukPuan REAL,
@oEnYuksekPuan REAL)
AS
BEGIN
	DECLARE @uniNo INT
	DECLARE @fakNo INT
	SET @uniNo = (SELECT TOP 1 Universite.uniNo FROM Universite WHERE uniAdi = @uniAdi)
	IF ISNULL(@uniNo,0)=0
		BEGIN
			IF @uniAdi !='' INSERT INTO Universite VALUES (@uniAdi,@il,NULL,NULL)
			ELSE return
			SET @uniNo = SCOPE_IDENTITY()
		END

	SET @fakNo = (SELECT TOP 1 Fakulte.fakNo FROM Fakulte WHERE fakAdi = @fakAdi)

	IF ISNULL(@fakNo,0)=0
		BEGIN
			INSERT INTO Fakulte VALUES(@fakAdi)
			SET @fakNo = SCOPE_IDENTITY()
		END	
	INSERT INTO UniFak VALUES (@uniNo,@fakNo)
	INSERT INTO Bolum VALUES (@bolumKodu,@bolAdi,@puanTuru,0,@kontenjan,@yerlesen,@enKucukPuan,@enYuksekPuan,@oEnKucukPuan,@oEnYuksekPuan)
	INSERT INTO UniFakBol VALUES(@uniNo,@fakNo,@bolumKodu)
END