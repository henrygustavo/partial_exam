CREATE TABLE category (
  category_id int(11) NOT NULL AUTO_INCREMENT,
  name varchar(45) NOT NULL,
  description varchar(45) DEFAULT NULL,
  PRIMARY KEY (category_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE product (
  product_id int(11) NOT NULL AUTO_INCREMENT,
  name varchar(50) NOT NULL,
  picture_url longtext NOT NULL,
  description longtext NOT NULL,
  price decimal(10,2) NOT NULL,
  currency varchar(3) NOT NULL,
  category_id int(11) DEFAULT NULL,
  PRIMARY KEY(product_id),
  CONSTRAINT product_category_id FOREIGN KEY (category_id) REFERENCES category (category_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE role (
  role_id int(11) NOT NULL AUTO_INCREMENT,
  role_name varchar(45) NOT NULL,
  PRIMARY KEY (role_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;


CREATE TABLE user (
  user_id int(11) NOT NULL AUTO_INCREMENT,
  user_name varchar(45) NOT NULL,
  password varchar(11) NOT NULL,
  role_id int(11) NOT NULL,
  PRIMARY KEY (user_id),
  CONSTRAINT user_role_id FOREIGN KEY (role_id) REFERENCES role (role_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
