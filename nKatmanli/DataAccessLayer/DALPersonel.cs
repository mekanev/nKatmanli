using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntityLayer;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi() 
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("select * from tbl_Bilgiler",Baglanti.baglanti);
            if (komut1.Connection.State!=ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel entity = new EntityPersonel();
                entity.Id = int.Parse(dr["Id"].ToString());
                entity.Ad = dr["Ad"].ToString();
                entity.Soyad = dr["Soyad"].ToString();
                entity.Sehir = dr["Sehir"].ToString();
                entity.Gorev = dr["Gorev"].ToString();
                entity.Maas = int.Parse(dr["Maas"].ToString());
                degerler.Add(entity);
            }
            dr.Close();
            return degerler;
        }
        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut2 = new SqlCommand("insert into tbl_Bilgiler (Ad,Soyad,Sehir,Gorev,Maas) values (@p1,@p2,@p3,@p4,@p5)", Baglanti.baglanti);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1", p.Ad);
            komut2.Parameters.AddWithValue("@p2", p.Soyad);
            komut2.Parameters.AddWithValue("@p3", p.Sehir);
            komut2.Parameters.AddWithValue("@p4", p.Gorev);
            komut2.Parameters.AddWithValue("@p5", p.Maas);
            return komut2.ExecuteNonQuery();
        }
        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("delete from tbl_Bilgiler where Id=@p1", Baglanti.baglanti);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", p);
            return komut3.ExecuteNonQuery()>0;
        }
        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand komut4 = new SqlCommand("update tbl_Bilgiler set Ad=@p1,Soyad=@p2,Maas=@p3,Sehir=@p4,Gorev=@p5 where Id=@p6", Baglanti.baglanti);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p1", ent.Ad);
            komut4.Parameters.AddWithValue("@p2", ent.Soyad);
            komut4.Parameters.AddWithValue("@p3", ent.Maas);
            komut4.Parameters.AddWithValue("@p4", ent.Sehir);
            komut4.Parameters.AddWithValue("@p5", ent.Gorev);
            komut4.Parameters.AddWithValue("@p6", ent.Id);
            return komut4.ExecuteNonQuery() > 0; 
        }

    }
}
