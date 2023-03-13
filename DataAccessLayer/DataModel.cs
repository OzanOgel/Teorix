using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Teori Işlemleri

        public bool TeoriSayisiArttir(int uyeid)
        {
            try
            {
                cmd.CommandText = "select ToplamTeoriSayısı from Uyeler where ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", uyeid);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                sayi = sayi + 1;
                cmd.CommandText = "update Uyeler set ToplamTeoriSayısı =@sayi where ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", uyeid);
                cmd.Parameters.AddWithValue("@sayi", sayi);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool teoriekle(Teoriler t)
        {
            try
            {
                cmd.CommandText = "insert into Teoriler(Tur_ID,Uye_ID,Yonetici_ID,PaylasilmaTarihi,içerik,BegeniSayısı,YanitSayisi,aktiflik,Yapım_ID) values(@tur_id,@uyeid,@Yonetici_id,@paylasilmatarihi,@içerik,@begenisayisi,@yanitsayisi,@aktiflik,@Yapim_ID)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tur_id", t.Tur_ID);
                cmd.Parameters.AddWithValue("@Yonetici_id", t.Yonetici_ID);
                cmd.Parameters.AddWithValue("@paylasilmatarihi", t.Paylasilma_Tarihi);
                cmd.Parameters.AddWithValue("@içerik", t.içerik);
                cmd.Parameters.AddWithValue("@begenisayisi", t.Begeni_Sayisi);
                cmd.Parameters.AddWithValue("@yanitsayisi", t.Yanit_Sayisi);
                cmd.Parameters.AddWithValue("@aktiflik", 1);
                cmd.Parameters.AddWithValue("@Yapim_ID", t.Yapım_ID);
                cmd.Parameters.AddWithValue("@uyeid", t.Uye_ID);
                con.Open();
                cmd.ExecuteReader();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public int teoriSayisi(int id)
        {
            cmd.CommandText = "select COUNT(*) from Teoriler where Yapım_ID=@id and aktiflik=1";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int sayi = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return sayi;
        }
        public List<Teoriler> TeoriListeleYapim(int yapim_ID)
        {
            try
            {
                List<Teoriler> teorilistesi = new List<Teoriler>();
                cmd.CommandText = "select t.ID ,t.Tur_ID,tu.isim,t.Yonetici_ID,y.isim +' '+y.SoyIsim,t.PaylasilmaTarihi,t.içerik,t.BegeniSayısı,t.YanitSayisi,t.aktiflik,t.Uye_ID,u.isim + ' ' + u.SoyIsim,t.Yapım_ID,ya.isim,u.Kullanici_Adi from Teoriler as t join Turler as tu on t.Tur_ID = tu.ID join Yoneticiler as y on t.Yonetici_ID=y.ID join Uyeler as u on t.Uye_ID=u.ID join Yapımlar as ya on t.Yapım_ID=ya.ID where t.Yapım_ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", yapim_ID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teoriler t = new Teoriler();
                    t.ID = reader.GetInt32(0);
                    t.Tur_ID = reader.GetInt32(1);
                    t.Tur = reader.GetString(2);
                    t.Yonetici_ID = reader.GetInt32(3);
                    t.Yonetici = reader.GetString(4);
                    t.Paylasilma_Tarihi = reader.GetDateTime(5);
                    t.içerik = reader.GetString(6);
                    t.Begeni_Sayisi = reader.GetInt32(7);
                    t.Yanit_Sayisi = reader.GetInt32(8);
                    t.aktiflik = reader.GetBoolean(9);
                    t.aktiflikStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                    t.Uye_ID = reader.GetInt32(10);
                    t.uyeIsim = reader.GetString(11);
                    t.Yapım_ID = reader.GetInt32(12);
                    t.Yapım = reader.GetString(13);
                    t.KullaniciAdi = reader.GetString(14);
                    t.tarihstr = reader.GetDateTime(5).ToString().TrimEnd('0', ':');
                    teorilistesi.Add(t);

                }
                return teorilistesi;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Teoriler> TeoriListele(int ID)
        {
            try
            {
                List<Teoriler> teorilistesi = new List<Teoriler>();
                cmd.CommandText = "select t.ID ,t.Tur_ID,tu.isim,t.Yonetici_ID,y.isim +' '+y.SoyIsim,t.PaylasilmaTarihi,t.içerik,t.BegeniSayısı,t.YanitSayisi,t.aktiflik,t.Uye_ID,u.isim + ' ' + u.SoyIsim,t.Yapım_ID,ya.isim,u.Kullanici_Adi from Teoriler as t join Turler as tu on t.Tur_ID = tu.ID join Yoneticiler as y on t.Yonetici_ID=y.ID join Uyeler as u on t.Uye_ID=u.ID join Yapımlar as ya on t.Yapım_ID=ya.ID where t.Tur_ID=@tur";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tur", ID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teoriler t = new Teoriler();
                    t.ID = reader.GetInt32(0);
                    t.Tur_ID = reader.GetInt32(1);
                    t.Tur = reader.GetString(2);
                    t.Yonetici_ID = reader.GetInt32(3);
                    t.Yonetici = reader.GetString(4);
                    t.Paylasilma_Tarihi = reader.GetDateTime(5);
                    t.içerik = reader.GetString(6);
                    t.Begeni_Sayisi = reader.GetInt32(7);
                    t.Yanit_Sayisi = reader.GetInt32(8);
                    t.aktiflik = reader.GetBoolean(9);
                    t.aktiflikStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                    t.Uye_ID = reader.GetInt32(10);
                    t.uyeIsim = reader.GetString(11);
                    t.Yapım_ID = reader.GetInt32(12);
                    t.Yapım = reader.GetString(13);
                    t.KullaniciAdi = reader.GetString(14);
                    t.tarihstr = reader.GetDateTime(5).ToString().TrimEnd('0', ':');
                    teorilistesi.Add(t);

                }
                return teorilistesi;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Teoriler> TeoriListele()
        {
            try
            {
                List<Teoriler> teorilistesi = new List<Teoriler>();
                cmd.CommandText = "select t.ID ,t.Tur_ID,tu.isim,t.Yonetici_ID,y.isim +' '+y.SoyIsim,t.PaylasilmaTarihi,t.içerik,t.BegeniSayısı,t.YanitSayisi,t.aktiflik,t.Uye_ID,u.isim + ' ' + u.SoyIsim,t.Yapım_ID,ya.isim,u.Kullanici_Adi from Teoriler as t join Turler as tu on t.Tur_ID = tu.ID join Yoneticiler as y on t.Yonetici_ID=y.ID join Uyeler as u on t.Uye_ID=u.ID join Yapımlar as ya on t.Yapım_ID=ya.ID";
                cmd.Parameters.Clear();

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teoriler t = new Teoriler();
                    t.ID = reader.GetInt32(0);
                    t.Tur_ID = reader.GetInt32(1);
                    t.Tur = reader.GetString(2);
                    t.Yonetici_ID = reader.GetInt32(3);
                    t.Yonetici = reader.GetString(4);
                    t.Paylasilma_Tarihi = reader.GetDateTime(5);
                    t.içerik = reader.GetString(6);
                    t.Begeni_Sayisi = reader.GetInt32(7);
                    t.Yanit_Sayisi = reader.GetInt32(8);
                    t.aktiflik = reader.GetBoolean(9);
                    t.aktiflikStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                    t.Uye_ID = reader.GetInt32(10);
                    t.uyeIsim = reader.GetString(11);
                    t.Yapım_ID = reader.GetInt32(12);
                    t.Yapım = reader.GetString(13);
                    t.KullaniciAdi = reader.GetString(14);
                    t.tarihstr = reader.GetDateTime(5).ToString().TrimEnd('0', ':');
                    teorilistesi.Add(t);

                }
                return teorilistesi;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }


        }
        public List<Teoriler> TekTeoriListele(int ID)
        {
            try
            {
                List<Teoriler> teorilistesi = new List<Teoriler>();
                cmd.CommandText = "select t.ID ,t.Tur_ID,tu.isim,t.Yonetici_ID,y.isim +' '+y.SoyIsim,t.PaylasilmaTarihi,t.içerik,t.BegeniSayısı,t.YanitSayisi,t.aktiflik,t.Uye_ID,u.isim + ' ' + u.SoyIsim,t.Yapım_ID,ya.isim,u.Kullanici_Adi from Teoriler as t join Turler as tu on t.Tur_ID = tu.ID join Yoneticiler as y on t.Yonetici_ID=y.ID join Uyeler as u on t.Uye_ID=u.ID join Yapımlar as ya on t.Yapım_ID=ya.ID where t.ID=@ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teoriler t = new Teoriler();
                    t.ID = reader.GetInt32(0);
                    t.Tur_ID = reader.GetInt32(1);
                    t.Tur = reader.GetString(2);
                    t.Yonetici_ID = reader.GetInt32(3);
                    t.Yonetici = reader.GetString(4);
                    t.Paylasilma_Tarihi = reader.GetDateTime(5);
                    t.içerik = reader.GetString(6);
                    t.Begeni_Sayisi = reader.GetInt32(7);
                    t.Yanit_Sayisi = reader.GetInt32(8);
                    t.aktiflik = reader.GetBoolean(9);
                    t.aktiflikStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                    t.Uye_ID = reader.GetInt32(10);
                    t.uyeIsim = reader.GetString(11);
                    t.Yapım_ID = reader.GetInt32(12);
                    t.Yapım = reader.GetString(13);
                    t.KullaniciAdi = reader.GetString(14);
                    t.tarihstr = reader.GetDateTime(5).ToString().TrimEnd('0', ':');
                    teorilistesi.Add(t);

                }
                return teorilistesi;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }


        }
        public bool TeoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE Yanitlar WHERE Teori_ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE Teoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Uye İşlemleri


        public int Kullaniciadikontrol(string kullaniciadi)
        {
            cmd.CommandText = "select COUNT(*) from Uyeler where Kullanici_Adi =@kullaniciadi";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("kullaniciadi", kullaniciadi);
            con.Open();
            int sayi = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return sayi;
        }

        public bool uyeekle(Uyeler u)
        {
            try
            {
                cmd.CommandText = "insert into Uyeler(Eposta,şifre,isim,SoyIsim,KayıtOlmaTarihi,ToplamTeoriSayısı,aktiflik,Kullanici_Adi) values(@Eposta,@sifre,@isim,@SoyIsim,@KayıtOlmaTarihi,@ToplamTeoriSayısı,1,@Kullanici_Adi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Eposta",u.KullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre",u.şifre);
                cmd.Parameters.AddWithValue("@isim",u.isim);
                cmd.Parameters.AddWithValue("@SoyIsim",u.soyisim);
                cmd.Parameters.AddWithValue("@KayıtOlmaTarihi",u.KayitOlmaTarihi);
                cmd.Parameters.AddWithValue("@ToplamTeoriSayısı",0);
                cmd.Parameters.AddWithValue("@Kullanici_Adi",u.KullaniciAdi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
                
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Uyeler uyegiriş(string mail, string sifre)
        {
            
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Eposta = @mail and şifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "select ID,Eposta,şifre,isim,SoyIsim,KayıtOlmaTarihi,ToplamTeoriSayısı,aktiflik,Kullanici_Adi from Uyeler where Eposta = @mail and şifre = @sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    SqlDataReader reader = cmd.ExecuteReader();
                    Uyeler u = new Uyeler();
                    while (reader.Read())

                    {
                        u.ID = reader.GetInt32(0);
                        u.Eposta = reader.GetString(1);
                        u.şifre = reader.GetString(2);
                        u.isim = reader.GetString(3);
                        u.soyisim = reader.GetString(4);
                       
                        u.KayitOlmaTarihi = reader.GetDateTime(5);
                        u.ToplamTeoriSayısı = reader.GetInt32(6);
                        u.aktiflik = reader.GetBoolean(7);
                        u.AktiflikStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                        u.KullaniciAdi = reader.GetString(8);
                    }
                    return u;
                }
                else { return null; }

            }

            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UyeBanla(int id)
        {
            try
            {
                cmd.CommandText = "update Uyeler set aktiflik= 0 where ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "update Teoriler set aktiflik=0 where Uye_ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();


                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UyeBanKaldır(int id)
        {
            try
            {
                cmd.CommandText = "update Uyeler set aktiflik= 1 where ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "update Teoriler set aktiflik=1 where Uye_ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();


                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Uyeler> UyeListele(int id)
        {
            try
            {
                List<Uyeler> uyelist = new List<Uyeler>();
                cmd.CommandText = "select Kullanici_Adi , Eposta,şifre,isim,SoyIsim,KayıtOlmaTarihi,ToplamTeoriSayısı,aktiflik,ID from Uyeler where aktiflik=@id";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uyeler u = new Uyeler();
                    u.KullaniciAdi = reader.GetString(0);
                    u.Eposta = reader.GetString(1);
                    u.şifre = reader.GetString(2);
                    u.isim = reader.GetString(3);
                    u.soyisim = reader.GetString(4);
                   
                    u.KayitOlmaTarihi = reader.GetDateTime(5);
                    u.ToplamTeoriSayısı = reader.GetInt32(6);
                    u.aktiflik = reader.GetBoolean(7);
                    u.AktiflikStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                    u.ID = reader.GetInt32(8);
                    uyelist.Add(u);

                }
                return uyelist;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Uyeler> UyeListele()
        {
            try
            {
                List<Uyeler> uyelist = new List<Uyeler>();
                cmd.CommandText = "select Kullanici_Adi , Eposta,şifre,isim,SoyIsim,KayıtOlmaTarihi,ToplamTeoriSayısı,aktiflik,ID from Uyeler";

                cmd.Parameters.Clear();

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uyeler u = new Uyeler();
                    u.KullaniciAdi = reader.GetString(0);
                    u.Eposta = reader.GetString(1);
                    u.şifre = reader.GetString(2);
                    u.isim = reader.GetString(3);
                    u.soyisim = reader.GetString(4);
                   
                    u.KayitOlmaTarihi = reader.GetDateTime(5);
                    u.ToplamTeoriSayısı = reader.GetInt32(6);
                    u.aktiflik = reader.GetBoolean(7);
                    u.AktiflikStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                    u.ID = reader.GetInt32(8);
                    uyelist.Add(u);

                }
                return uyelist;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Yapım İşlemleri
        public List<Yapımlar> AktifYapımLislete()
        {
            try
            {
                List<Yapımlar> YapımlarList = new List<Yapımlar>();
                cmd.CommandText = "select y.ID,y.Tur_ID,y.Yonetici_ID,y.isim,y.resim, yo.Kullanici_Adi ,t.isim,y.Aktiflik from Yapımlar as y join Yoneticiler as yo on y.Yonetici_ID = yo.ID join Turler as t on y.Tur_ID=t.ID where y.Aktiflik=1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yapımlar y = new Yapımlar();
                    y.ID = reader.GetInt32(0);
                    y.Tur_ID = reader.GetInt32(1);
                    y.Yonetici_ID = reader.GetInt32(2);
                    y.Isim = reader.GetString(3);
                    y.Resim = reader.GetString(4);
                    y.Yonetici = reader.GetString(5);
                    y.Tur = reader.GetString(6);
                    y.aktiflik = reader.GetBoolean(7);
                    y.AktiflikStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    YapımlarList.Add(y);
                }
                return YapımlarList;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public List<Yapımlar> YapımLislete()
        {
            try
            {
                List<Yapımlar> YapımlarList = new List<Yapımlar>();
                cmd.CommandText = "select y.ID,y.Tur_ID,y.Yonetici_ID,y.isim,y.resim, yo.Kullanici_Adi ,t.isim,y.Aktiflik from Yapımlar as y join Yoneticiler as yo on y.Yonetici_ID = yo.ID join Turler as t on y.Tur_ID=t.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yapımlar y = new Yapımlar();
                    y.ID = reader.GetInt32(0);
                    y.Tur_ID = reader.GetInt32(1);
                    y.Yonetici_ID = reader.GetInt32(2);
                    y.Isim = reader.GetString(3);
                    y.Resim = reader.GetString(4);
                    y.Yonetici = reader.GetString(5);
                    y.Tur = reader.GetString(6);
                    y.aktiflik = reader.GetBoolean(7);
                    y.AktiflikStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    YapımlarList.Add(y);
                }
                return YapımlarList;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }
        public List<Yapımlar> YapımLislete(int Tur_ID)
        {
            try
            {
                List<Yapımlar> YapımlarList = new List<Yapımlar>();
                cmd.CommandText = "select y.ID,y.Tur_ID,y.Yonetici_ID,y.isim,y.resim, yo.Kullanici_Adi ,t.isim,y.Aktiflik from Yapımlar as y join Yoneticiler as yo on y.Yonetici_ID = yo.ID join Turler as t on y.Tur_ID=t.ID where y.Tur_ID = @turid and y.Aktiflik = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("turid", Tur_ID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yapımlar y = new Yapımlar();
                    y.ID = reader.GetInt32(0);
                    y.Tur_ID = reader.GetInt32(1);
                    y.Yonetici_ID = reader.GetInt32(2);
                    y.Isim = reader.GetString(3);
                    y.Resim = reader.GetString(4);
                    y.Yonetici = reader.GetString(5);
                    y.Tur = reader.GetString(6);
                    y.aktiflik = reader.GetBoolean(7);
                    y.AktiflikStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    YapımlarList.Add(y);
                }
                return YapımlarList;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public bool YapimEkle(Yapımlar y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yapımlar(Tur_ID,Yonetici_ID,isim,resim,Aktiflik) VALUES(@Tur_ID,@Yonetici_ID,@isim,@resim,@Aktiflik)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Tur_ID", y.Tur_ID);
                cmd.Parameters.AddWithValue("@Yonetici_ID", y.Yonetici_ID);
                cmd.Parameters.AddWithValue("@isim", y.Isim);
                cmd.Parameters.AddWithValue("@resim", y.Resim);
                cmd.Parameters.AddWithValue("@Aktiflik", y.aktiflik);

                con.Open();
                cmd.ExecuteReader();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool YapimDuzenle(Yapımlar y)
        {
            try
            {
                cmd.CommandText = "UPDATE Yapımlar set Tur_ID=@Tur_ID ,Yonetici_ID=@Yonetici_ID,isim=@isim,resim=@resim,Aktiflik=@Aktiflik where ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", y.ID);
                cmd.Parameters.AddWithValue("@Tur_ID", y.Tur_ID);
                cmd.Parameters.AddWithValue("@Yonetici_ID", y.Yonetici_ID);
                cmd.Parameters.AddWithValue("@isim", y.Isim);
                cmd.Parameters.AddWithValue("@resim", y.Resim);
                cmd.Parameters.AddWithValue("@Aktiflik", y.aktiflik);

                con.Open();
                cmd.ExecuteReader();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YapimSil(int id)
        {
            try
            {
                cmd.CommandText = "delete Teoriler where Yapım_ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "delete Yapımlar where ID = @id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Yapımlar YapimGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT y.ID,y.Tur_ID,Y.Yonetici_ID,y.isim,y.resim,y.Aktiflik,t.isim,yo.Kullanici_Adi FROM Yapımlar AS y JOIN Turler AS t ON M.Tur_ID= t.ID JOIN Yoneticiler AS yo ON M.Yonetici_ID = yo.ID WHERE y.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                Yapımlar y = new Yapımlar();
                while (reader.Read())
                {
                    y.ID = reader.GetInt32(0);
                    y.Tur_ID = reader.GetInt32(1);
                    y.Yonetici_ID = reader.GetInt32(2);
                    y.Isim = reader.GetString(3);
                    y.Resim = reader.GetString(4);
                    y.aktiflik = reader.GetBoolean(5);
                    y.AktiflikStr = reader.GetBoolean(5) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    y.Tur = reader.GetString(6);
                    y.Yonetici = reader.GetString(7);


                }
                return y;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Yönetici İşlemleri
        public Yoneticiler AdminGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Eposta = @mail and Sifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID,Y.isim, Y.SoyIsim,Y.Kullanici_Adi, Y.Sifre,Y.Eposta,Y.aktiflik, YT.isim,Y.KayıtOlmaTarihi FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID WHERE Y.Eposta = @mail AND Y.Sifre = @sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    SqlDataReader reader = cmd.ExecuteReader();
                    Yoneticiler y = new Yoneticiler();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTur_ID = reader.GetInt32(1);
                        y.isim = reader.GetString(2);
                        y.soyisim = reader.GetString(3);
                        y.Kullanici_Adi = reader.GetString(4);
                        y.şifre = reader.GetString(5);
                        y.Eposta = reader.GetString(6);
                        y.aktiflik = reader.GetBoolean(7);
                        y.AktiflikStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                        y.YoneticiTur = reader.GetString(8);
                        y.KayitOlmaTarihi = reader.GetDateTime(9);
                    }
                    return y;
                }

                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        public List<Yoneticiler> YoneticiListele()
        {
            try
            {
                List<Yoneticiler> Yoneticilist = new List<Yoneticiler>();
                cmd.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID,Y.isim, Y.SoyIsim,Y.Kullanici_Adi, Y.Sifre,Y.Eposta,Y.aktiflik, YT.isim,Y.KayıtOlmaTarihi FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID where YT.ID = 1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yoneticiler y = new Yoneticiler();
                    y.ID = reader.GetInt32(0);
                    y.YoneticiTur_ID = reader.GetInt32(1);
                    y.isim = reader.GetString(2);
                    y.soyisim = reader.GetString(3);
                    y.Kullanici_Adi = reader.GetString(4);
                    y.şifre = reader.GetString(5);
                    y.Eposta = reader.GetString(6);
                    y.aktiflik = reader.GetBoolean(7);
                    y.AktiflikStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    y.YoneticiTur = reader.GetString(8);
                    y.KayitOlmaTarihi = reader.GetDateTime(9);
                    Yoneticilist.Add(y);

                }
                return Yoneticilist;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }
        public List<Yoneticiler> YoneticiListele(int id)
        {
            try
            {
                List<Yoneticiler> Yoneticilist = new List<Yoneticiler>();
                cmd.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID,Y.isim, Y.SoyIsim,Y.Kullanici_Adi, Y.Sifre,Y.Eposta,Y.aktiflik, YT.isim,Y.KayıtOlmaTarihi FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID where YT.ID = 1 and aktiflik=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yoneticiler y = new Yoneticiler();
                    y.ID = reader.GetInt32(0);
                    y.YoneticiTur_ID = reader.GetInt32(1);
                    y.isim = reader.GetString(2);
                    y.soyisim = reader.GetString(3);
                    y.Kullanici_Adi = reader.GetString(4);
                    y.şifre = reader.GetString(5);
                    y.Eposta = reader.GetString(6);
                    y.aktiflik = reader.GetBoolean(7);
                    y.AktiflikStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    y.YoneticiTur = reader.GetString(8);
                    y.KayitOlmaTarihi = reader.GetDateTime(9);
                    Yoneticilist.Add(y);

                }
                return Yoneticilist;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public bool YoneticiBanla(int id)
        {
            try
            {
                cmd.CommandText = "update Yoneticiler set aktiflik=0 where ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool YoneticiBanKaldir(int id)
        {
            try
            {
                cmd.CommandText = "update Yoneticiler set aktiflik=1 where ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }


        #endregion

        #region Tür İşlemleri
        public List<Turler> TurListele()
        {
            List<Turler> turlerlist = new List<Turler>();
            try
            {
                cmd.CommandText = "SELECT ID , isim FROM Turler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Turler t = new Turler();
                    t.ID = reader.GetInt32(0);
                    t.isim = reader.GetString(1);

                    turlerlist.Add(t);
                }
                return turlerlist;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public int yapimIDyegoreturgetir(int id)
        {
            try
            {
                cmd.CommandText = "select Tur_ID from Yapımlar where ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                return sayi;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Yanıt İşlemleri
        public List<Yanitlar> BekleyenYanitListele()
        {
            try
            {
                List<Yanitlar> Onaybekleyenyanitlar = new List<Yanitlar>();
                cmd.CommandText = "select y.ID ,y.Teori_ID,y.Uye_ID,y.PaylaşılmaTarihi,y.içerik,y.BegeniSayisi,y.aktiflik,u.Kullanici_Adi from Yanitlar as y join Uyeler as u on y.Uye_ID =u.ID where y.durum = 'Onay Bekliyor' ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yanitlar y = new Yanitlar();
                    y.ID = reader.GetInt32(0);
                    y.Teori_ID = reader.GetInt32(1);
                    y.Uye_ID = reader.GetInt32(2);
                    y.PaylasilmaTarihi = reader.GetDateTime(3);
                    y.icerik = reader.GetString(4);
                    y.BegeniSayisi = reader.GetInt32(5);
                    y.aktiflik = reader.GetBoolean(6);
                    y.aktiflikStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    y.Uye = reader.GetString(7);
                    Onaybekleyenyanitlar.Add(y);
                }
                return Onaybekleyenyanitlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool yanitonayla(int id)
        {
            try
            {
                cmd.CommandText = "update Yanitlar set durum = 'Onaylandı' where ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "update Yanitlar set aktiflik = 1 where ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool yanitReddet(int id)
        {
            try
            {
                cmd.CommandText = "update Yanitlar set durum = 'Reddedildi' where ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "update Yanitlar set aktiflik = 0 where ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yanitlar> OnaylananYanitListele()
        {
            try
            {
                List<Yanitlar> Onaybekleyenyanitlar = new List<Yanitlar>();
                cmd.CommandText = "select y.ID ,y.Teori_ID,y.Uye_ID,y.PaylaşılmaTarihi,y.içerik,y.BegeniSayisi,y.aktiflik,u.Kullanici_Adi from Yanitlar as y join Uyeler as u on y.Uye_ID =u.ID where y.durum = 'Onaylandı' ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yanitlar y = new Yanitlar();
                    y.ID = reader.GetInt32(0);
                    y.Teori_ID = reader.GetInt32(1);
                    y.Uye_ID = reader.GetInt32(2);
                    y.PaylasilmaTarihi = reader.GetDateTime(3);
                    y.icerik = reader.GetString(4);
                    y.BegeniSayisi = reader.GetInt32(5);
                    y.aktiflik = reader.GetBoolean(6);
                    y.aktiflikStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    y.Uye = reader.GetString(7);
                    Onaybekleyenyanitlar.Add(y);
                }
                return Onaybekleyenyanitlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yanitlar> ReddedilenYanitListele()
        {
            try
            {
                List<Yanitlar> Onaybekleyenyanitlar = new List<Yanitlar>();
                cmd.CommandText = "select y.ID ,y.Teori_ID,y.Uye_ID,y.PaylaşılmaTarihi,y.içerik,y.BegeniSayisi,y.aktiflik,u.Kullanici_Adi from Yanitlar as y join Uyeler as u on y.Uye_ID =u.ID where y.durum = 'Reddedildi' ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yanitlar y = new Yanitlar();
                    y.ID = reader.GetInt32(0);
                    y.Teori_ID = reader.GetInt32(1);
                    y.Uye_ID = reader.GetInt32(2);
                    y.PaylasilmaTarihi = reader.GetDateTime(3);
                    y.icerik = reader.GetString(4);
                    y.BegeniSayisi = reader.GetInt32(5);
                    y.aktiflik = reader.GetBoolean(6);
                    y.aktiflikStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    y.Uye = reader.GetString(7);
                    Onaybekleyenyanitlar.Add(y);
                }
                return Onaybekleyenyanitlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yanitlar> AktifYanitListele(int id)
        {
            try
            {
                List<Yanitlar> yanitlar = new List<Yanitlar>();
                cmd.CommandText = "select y.ID ,y.Teori_ID,y.Uye_ID,y.PaylaşılmaTarihi,y.içerik,y.BegeniSayisi,y.aktiflik,u.Kullanici_Adi from Yanitlar as y join Uyeler as u on y.Uye_ID =u.ID where y.aktiflik=1 and Teori_ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yanitlar y = new Yanitlar();
                    y.ID = reader.GetInt32(0);
                    y.Teori_ID = reader.GetInt32(1);
                    y.Uye_ID = reader.GetInt32(2);
                    y.PaylasilmaTarihi = reader.GetDateTime(3);
                    y.icerik = reader.GetString(4);
                    y.BegeniSayisi = reader.GetInt32(5);
                    y.aktiflik = reader.GetBoolean(6);
                    y.aktiflikStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    y.Uye = reader.GetString(7);
                    yanitlar.Add(y);
                }
                return yanitlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public int YanitSayisi(int id)
        {
            cmd.CommandText = "select COUNT(*) from Yanitlar where Teori_ID=@id and aktiflik=1";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int sayi = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return sayi;
        }
        public bool yanitekle(Yanitlar y)
        {
            try
            {
                cmd.CommandText = "insert into Yanitlar(Teori_ID,Uye_ID,Yonetici_ID,PaylaşılmaTarihi,içerik,BegeniSayisi,aktiflik,durum) values(@teoriid,@uyeid,1,@paylasilmatarihi,@içerik,@begenisayisi,1,'Onay Bekliyor')";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@teoriid",y.Teori_ID);
                cmd.Parameters.AddWithValue("@uyeid",y.Uye_ID);
                
                cmd.Parameters.AddWithValue("@paylasilmatarihi",y.PaylasilmaTarihi);
                cmd.Parameters.AddWithValue("@içerik",y.icerik);
                cmd.Parameters.AddWithValue("@begenisayisi",y.BegeniSayisi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
       
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

    }
}
