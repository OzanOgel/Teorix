<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciPaneli/Kullanicipnl.Master" AutoEventWireup="true" CodeBehind="Yanitlar.aspx.cs" Inherits="TeorixProject.KullaniciPaneli.Yanitlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style>
        .heart {
            color: grey;
            cursor: pointer;
            font-size: 20px;
        }



            .heart.active {
                color: red;
                animation-name: fillHeart;
                animation-duration: 0.5s;
            }

        @keyframes fillHeart {
            0% {
                transform: scale(1);
            }

            50% {
                transform: scale(1.2);
            }

            100% {
                transform: scale(1);
            }
        }
    </style>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const hearts = document.querySelectorAll(".heart");
            hearts.forEach(heart => {
                heart.addEventListener("click", function () {
                    this.classList.toggle("active");
                });
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:Panel ID="pnl_girisvar" runat="server" CssClass="girisvar" >
            <asp:TextBox ID="tb_yorum" runat="server"  CssClass="forminput" TextMode="MultiLine"></asp:TextBox>
            <br /><br />
            <asp:LinkButton ID="lbtn_yorumYap" runat="server" CssClass="formbutton">Yanıt Paylaş</asp:LinkButton>
        </asp:Panel>
    <asp:Panel ID="pnl_UyeOl" runat="server" Visible="false"></asp:Panel>
   <div style="margin-top:50px; margin-left:auto; margin-right:auto; width: 800px; height: 100px; text-align: center; font-size: 24px; border: 1px solid red; display: flex; align-items: center; justify-content: center;">
  
  <span style="color: red;"> <i class="fa-solid fa-ban"></i> Yanıt Paylaşabilmek için <a href="#" style="text-decoration:none; color: red; color:cornflowerblue; text-decoration:underline;">üye</a> olmalısınız</span>
</div>

    <asp:Panel runat="server" ID="pnl_Teoriyok" CssClass="teorinone" Visible="false">
        <label><i style="padding-right: 20px; font-size: 20pt;" class="fa-solid fa-ban"></i>Bu Yapımla ilgili Teori Paylaşılmamış!</label>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnl_Teoriler" CssClass="Teoriler">
        <h3 style="font-size:25pt;font-family: 'Cabin', sans-serif; margin-left:700px;">Yanıtlar</h3>
        <asp:Repeater ID="rp_Yanitlarkullanici" runat="server" OnItemCommand="rp_Yanitlarkullanici_ItemCommand">
            <ItemTemplate>
                <div style="margin-top: 50px;">
                    <div class="isim"><%# Eval("Uye") %>:</div>
                    <div class="contanierTeoriler">
                        <%# Eval("icerik") %>
                    </div>
                    <div class="teoribilgiler">
                        <ul>
                            <li>Tarih(<%# Eval("PaylasilmaTarihi") %>) |</li>
                            <li>Beğeni Sayısı( <%# Eval("BegeniSayisi") %> ) <i class="far fa-heart heart"></i>|</li>
                            

                            </li>
                        </ul>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>
