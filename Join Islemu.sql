select DersAd,Sinav1,Sinav2,Sinav3,Proje,Ortalama,Durum from tbl_Notlar 
inner join tbl_Dersler on tbl_Notlar.DersId=tbl_Dersler.DersId where OgrId=1


select ogrAd,OgrSoyad from tbl_Ogrenciler where OgrId=1