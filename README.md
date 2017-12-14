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


---------------------------------------------------

DECLARE @checkIn Datetime2(2)='2017-12-09'
DECLARE @checkOut DATETIME2(2)='2017-12-21'

SELECT RoomID FROM Room WHERE RoomID NOT IN (SELECT r.RoomID FROM Room r
				INNER JOIN Booked b ON b.RoomID=r.RoomID
				WHERE (@checkIn BETWEEN b.Check_In AND b.Check_Out)
						OR (@checkOut BETWEEN b.Check_In AND b.Check_Out)
						OR(b.Check_In BETWEEN @checkIn AND @checkOut)
						OR(b.Check_Out BETWEEN @checkIn AND @checkOut))
						
						
----------------------------------------------------
        <%-- Panel Beginning --%>
        <div class="panel panel-warning">
            <%-- panel header beginning --%>
            <div class="panel-heading">
                <h3 class="panel-title">1.Kişi Bilgileri</h3>
            </div>
            <%-- panel header end --%>
            <%-- panel body beginning --%>
            <div class="panel-body">
                <%-- headerLabels beginning --%>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-3 control-label">First Name</label>
                    <label for="inputEmail3" class="col-sm-3 control-label">Last Name</label>
                    <label for="inputEmail3" class="col-sm-3 control-label">Civilization Number</label>
                </div>
                <%-- Header labels end --%>
                <%-- TextBoxes Beginning --%>
                <div class="form-group">
                    <div class="col-sm-3 col-sm-offset-1">
                        <asp:TextBox ID="txtFirstName" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-3 ">
                        <asp:TextBox ID="txtLastName" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-3 ">
                        <asp:TextBox ID="txtCivilizationNumber" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <%-- textBox --%>
            </div>
        </div>						
						
						
						
