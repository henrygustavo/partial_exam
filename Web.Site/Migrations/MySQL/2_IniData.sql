INSERT INTO category(name, description) 
VALUES ('computers', 'computers');


INSERT INTO product(name,picture_url, description,price,currency,category_id) 
VALUES ('computer acer', 'https://static.acer.com/up/Resource/Acer/Laptops/Chromebook_Spin_11/Image/20170502/Chromebook-Spin-11_black_preview.png','computer acer',600,978,LAST_INSERT_ID()),
('computer lenovo', 'https://assets.pcmag.com/media/images/344350-lenovo-thinkpad-t440s.jpg?width=1000&height=743','computer lenovo',1000,978,LAST_INSERT_ID()),
('computer hp', 'https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c05491658.png','computer lenovo',3000,978,LAST_INSERT_ID());
