CREATE PROCEDURE [dbo].[LiseKaydet](
@il NVARCHAR(50),
@ilce NVARCHAR(50),
@okulAdi NVARCHAR(200),
@tabanPuan REAL,
@okulTuru NVARCHAR(50),
@yabanciDil NVARCHAR(50) )
AS
BEGIN
DECLARE @ilNo INT 
DECLARE @ilceNo INT
DECLARE @iletNo INT
DECLARE @turNo INT
DECLARE @dilNo INT
IF (@yabanciDil = '
Dil
') RETURN
IF (@okulTuru = '
Tür
') RETURN
SET @ilNo = (SELECT Il.ilNo FROM Il WHERE Il.ilAdi = + @il)
IF(ISNULL( @ilNo ,0)=0) RETURN
ELSE 
	BEGIN 
		SET @ilceNo = (SELECT Ilce.ilceNo FROM Ilce WHERE Ilce.ilceAdi = + @ilce)
		IF(ISNULL(@ilceNo,0) = 0)
			BEGIN
				INSERT INTO Ilce VALUES(@ilce)
				SET @ilceNo = SCOPE_IDENTITY();
			END
		SET @iletNo = (SELECT Iletisim.iletNo FROM Iletisim WHERE Iletisim.ilNo = + @ilNo AND Iletisim.ilceNo = +  @ilceNo)
		IF(ISNULL(@iletNo,0)=0) 
			BEGIN
				INSERT INTO Iletisim VALUES (@ilNo,@ilceNo)
				SET @iletNo = SCOPE_IDENTITY();
			END

		SET @turNo = (SELECT OkulTuru.turNo FROM OkulTuru WHERE OkulTuru.turAdi = + @okulTuru)
		IF(ISNULL(@turNo,0)=0) 
			BEGIN
				INSERT INTO OkulTuru VALUES (@okulTuru)
				SET @turNo = SCOPE_IDENTITY();
			END

		SET @dilNo = (SELECT YabanciDil.dilNo FROM YabanciDil WHERE YabanciDil.dilAdi = + @yabanciDil)
		IF(ISNULL(@dilNo,0)=0) 
			BEGIN
				INSERT INTO YabanciDil VALUES (@yabanciDil)
				SET @dilNo = SCOPE_IDENTITY();
			END

		INSERT INTO Okul VALUES (@okulAdi,@tabanPuan,@iletNo,@turNo,@dilNo)
	END
END
