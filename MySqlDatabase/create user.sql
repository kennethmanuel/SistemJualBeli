CREATE USER 'nancy'@'localhost' IDENTIFIED BY 'abc';
GRANT ALL PRIVILEGES ON si_jual_beli.* TO 'nancy'@'localhost';

CREATE USER 'andrew'@'localhost' IDENTIFIED BY '1234';
GRANT ALL PRIVILEGES ON si_jual_beli.* TO 'andrew'@'localhost' WITH GRANT OPTION;

CREATE USER 'janet'@'localhost' IDENTIFIED BY 'janet123';
GRANT ALL PRIVILEGES ON si_jual_beli.* TO 'janet'@'localhost';

CREATE USER 'margaret'@'localhost' IDENTIFIED BY 'margaret';
GRANT ALL PRIVILEGES ON si_jual_beli.* TO 'margaret'@'localhost';

CREATE USER 'steve'@'localhost' IDENTIFIED BY 'steve123';
GRANT ALL PRIVILEGES ON si_jual_beli.* TO 'steve'@'localhost';

CREATE USER 'michael'@'localhost' IDENTIFIED BY '123';
GRANT ALL PRIVILEGES ON si_jual_beli.* TO 'michael'@'localhost';

