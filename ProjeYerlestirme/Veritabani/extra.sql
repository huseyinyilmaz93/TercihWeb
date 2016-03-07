ALTER PROCEDURE [dbo].[extra] (
@il NVARCHAR(50),
@puan REAL )
AS
BEGIN
DECLARE @okulNo INT
SET @okulNo = (SELECT top 1 Okul.okulNo FROM Okul INNER JOIN Iletisim ON Okul.iletNo = Iletisim.iletNo
	INNER JOIN Il ON Il.ilNo = Iletisim.ilNo WHERE tabanPuani=0 AND Il.ilAdi =+@il )
	IF(ISNULL(@okulNo,0)=0) RETURN
UPDATE Okul SET Okul.tabanPuani = + @puan WHERE okulNo = +@okulNo
END