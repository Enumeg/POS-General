-- --------------------------------------------------------
-- Host:                         Mostafa-pc
-- Server version:               5.6.16-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             8.3.0.4694
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping database structure for poss
CREATE DATABASE IF NOT EXISTS `poss` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `poss`;


-- Dumping structure for table poss.accounts_types
CREATE TABLE IF NOT EXISTS `accounts_types` (
  `acc_id` int(10) NOT NULL AUTO_INCREMENT,
  `acc_name` varchar(50) NOT NULL,
  `acc_type` tinyint(4) NOT NULL,
  PRIMARY KEY (`acc_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- Dumping data for table poss.accounts_types: ~6 rows (approximately)
/*!40000 ALTER TABLE `accounts_types` DISABLE KEYS */;
INSERT INTO `accounts_types` (`acc_id`, `acc_name`, `acc_type`) VALUES
	(1, 'راتب', 0),
	(2, 'حوافز', 0),
	(3, 'مكافأة', 0),
	(4, 'سلفة', 1),
	(5, 'خصم', 1),
	(7, 'اجازة', 1);
/*!40000 ALTER TABLE `accounts_types` ENABLE KEYS */;


-- Dumping structure for table poss.buy
CREATE TABLE IF NOT EXISTS `buy` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `supplier_id` int(11) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `date` date NOT NULL,
  `paid` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_buy_suppliers` (`supplier_id`),
  CONSTRAINT `FK_buy_suppliers` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`sup_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table poss.buy: ~0 rows (approximately)
/*!40000 ALTER TABLE `buy` DISABLE KEYS */;
/*!40000 ALTER TABLE `buy` ENABLE KEYS */;


-- Dumping structure for table poss.buy_details
CREATE TABLE IF NOT EXISTS `buy_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `buy_id` int(11) NOT NULL,
  `material_id` int(11) NOT NULL,
  `unit` smallint(2) NOT NULL,
  `amount` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_buy_details_buy` (`buy_id`),
  KEY `FK_buy_details_materials` (`material_id`),
  CONSTRAINT `FK_buy_details_buy` FOREIGN KEY (`buy_id`) REFERENCES `buy` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_buy_details_materials` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table poss.buy_details: ~0 rows (approximately)
/*!40000 ALTER TABLE `buy_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `buy_details` ENABLE KEYS */;


-- Dumping structure for table poss.categories
CREATE TABLE IF NOT EXISTS `categories` (
  `cat_id` int(10) NOT NULL AUTO_INCREMENT,
  `cat_name` varchar(50) NOT NULL,
  PRIMARY KEY (`cat_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.categories: ~4 rows (approximately)
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` (`cat_id`, `cat_name`) VALUES
	(1, 'hard'),
	(2, 'MB'),
	(3, 'Ram'),
	(4, 'dfdsf');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;


-- Dumping structure for table poss.customers
CREATE TABLE IF NOT EXISTS `customers` (
  `cus_id` int(10) NOT NULL AUTO_INCREMENT,
  `cus_per_id` int(10) NOT NULL,
  `cus_balance` int(10) NOT NULL,
  PRIMARY KEY (`cus_id`),
  KEY `FK_customers_persons` (`cus_per_id`),
  CONSTRAINT `FK_customers_persons` FOREIGN KEY (`cus_per_id`) REFERENCES `persons` (`per_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.customers: ~2 rows (approximately)
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` (`cus_id`, `cus_per_id`, `cus_balance`) VALUES
	(1, 4, 12312),
	(2, 5, 2000);
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;


-- Dumping structure for table poss.damaged_buy
CREATE TABLE IF NOT EXISTS `damaged_buy` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `material_id` int(11) NOT NULL,
  `unit` smallint(2) NOT NULL,
  `amount` int(11) NOT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table poss.damaged_buy: ~0 rows (approximately)
/*!40000 ALTER TABLE `damaged_buy` DISABLE KEYS */;
/*!40000 ALTER TABLE `damaged_buy` ENABLE KEYS */;


-- Dumping structure for table poss.employees
CREATE TABLE IF NOT EXISTS `employees` (
  `emp_id` int(10) NOT NULL AUTO_INCREMENT,
  `emp_per_id` int(10) NOT NULL,
  `emp_job_id` int(10) NOT NULL,
  `emp_salary` decimal(10,2) NOT NULL,
  `emp_join_date` date DEFAULT NULL,
  PRIMARY KEY (`emp_id`),
  KEY `FK_Employees_persons` (`emp_per_id`),
  KEY `FK_employees_jobs` (`emp_job_id`),
  CONSTRAINT `FK_employees_jobs` FOREIGN KEY (`emp_job_id`) REFERENCES `jobs` (`job_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Employees_persons` FOREIGN KEY (`emp_per_id`) REFERENCES `persons` (`per_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.employees: ~2 rows (approximately)
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` (`emp_id`, `emp_per_id`, `emp_job_id`, `emp_salary`, `emp_join_date`) VALUES
	(1, 1, 1, 21.00, '2013-06-19'),
	(2, 2, 1, 2000.00, '2013-06-20');
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;


-- Dumping structure for table poss.employees_accounts
CREATE TABLE IF NOT EXISTS `employees_accounts` (
  `ema_id` int(10) NOT NULL AUTO_INCREMENT,
  `ema_no` int(10) NOT NULL,
  `ema_acc_id` int(11) NOT NULL,
  `ema_emp_id` int(11) NOT NULL,
  `ema_date` date NOT NULL,
  `ema_value` decimal(10,2) NOT NULL,
  `ema_description` varchar(500) NOT NULL,
  PRIMARY KEY (`ema_id`),
  KEY `FK_employees_accounts_accounts_types` (`ema_acc_id`),
  KEY `FK_employees_accounts_employees` (`ema_emp_id`),
  CONSTRAINT `employees_accounts_ibfk_1` FOREIGN KEY (`ema_acc_id`) REFERENCES `accounts_types` (`acc_id`),
  CONSTRAINT `employees_accounts_ibfk_2` FOREIGN KEY (`ema_emp_id`) REFERENCES `employees` (`emp_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- Dumping data for table poss.employees_accounts: ~0 rows (approximately)
/*!40000 ALTER TABLE `employees_accounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `employees_accounts` ENABLE KEYS */;


-- Dumping structure for table poss.groups
CREATE TABLE IF NOT EXISTS `groups` (
  `grp_id` int(10) NOT NULL AUTO_INCREMENT,
  `grp_name` varchar(50) NOT NULL,
  PRIMARY KEY (`grp_id`,`grp_name`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.groups: ~1 rows (approximately)
/*!40000 ALTER TABLE `groups` DISABLE KEYS */;
INSERT INTO `groups` (`grp_id`, `grp_name`) VALUES
	(1, 'Group1');
/*!40000 ALTER TABLE `groups` ENABLE KEYS */;


-- Dumping structure for table poss.jobs
CREATE TABLE IF NOT EXISTS `jobs` (
  `job_id` int(10) NOT NULL AUTO_INCREMENT,
  `job_name` varchar(100) NOT NULL,
  `job_grp_id` int(10) NOT NULL,
  PRIMARY KEY (`job_id`),
  KEY `FK_jobs_groups` (`job_grp_id`),
  CONSTRAINT `FK_jobs_groups` FOREIGN KEY (`job_grp_id`) REFERENCES `groups` (`grp_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- Dumping data for table poss.jobs: ~1 rows (approximately)
/*!40000 ALTER TABLE `jobs` DISABLE KEYS */;
INSERT INTO `jobs` (`job_id`, `job_name`, `job_grp_id`) VALUES
	(1, 'JOb1', 1);
/*!40000 ALTER TABLE `jobs` ENABLE KEYS */;


-- Dumping structure for table poss.materials
CREATE TABLE IF NOT EXISTS `materials` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table poss.materials: ~0 rows (approximately)
/*!40000 ALTER TABLE `materials` DISABLE KEYS */;
/*!40000 ALTER TABLE `materials` ENABLE KEYS */;


-- Dumping structure for table poss.outcome
CREATE TABLE IF NOT EXISTS `outcome` (
  `out_id` int(250) NOT NULL AUTO_INCREMENT,
  `out_date` date NOT NULL,
  `out_value` decimal(10,2) NOT NULL,
  `out_description` varchar(300) NOT NULL,
  `out_ott_id` int(10) NOT NULL,
  `out_pon_id` int(10) DEFAULT NULL,
  PRIMARY KEY (`out_id`),
  KEY `FK_Outcome_points` (`out_pon_id`),
  KEY `FK_outcome_outcome_types` (`out_ott_id`),
  CONSTRAINT `FK_outcome_outcome_types` FOREIGN KEY (`out_ott_id`) REFERENCES `outcome_types` (`ott_id`),
  CONSTRAINT `FK_Outcome_points` FOREIGN KEY (`out_pon_id`) REFERENCES `points` (`pon_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.outcome: ~1 rows (approximately)
/*!40000 ALTER TABLE `outcome` DISABLE KEYS */;
INSERT INTO `outcome` (`out_id`, `out_date`, `out_value`, `out_description`, `out_ott_id`, `out_pon_id`) VALUES
	(2, '2014-04-08', 8.00, 'keda', 2, 2);
/*!40000 ALTER TABLE `outcome` ENABLE KEYS */;


-- Dumping structure for table poss.outcome_types
CREATE TABLE IF NOT EXISTS `outcome_types` (
  `ott_id` int(10) NOT NULL AUTO_INCREMENT,
  `ott_name` varchar(100) NOT NULL,
  PRIMARY KEY (`ott_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='انواع المصروفات';

-- Dumping data for table poss.outcome_types: ~2 rows (approximately)
/*!40000 ALTER TABLE `outcome_types` DISABLE KEYS */;
INSERT INTO `outcome_types` (`ott_id`, `ott_name`) VALUES
	(1, 'out_typ1'),
	(2, 'out_type2');
/*!40000 ALTER TABLE `outcome_types` ENABLE KEYS */;


-- Dumping structure for table poss.payments
CREATE TABLE IF NOT EXISTS `payments` (
  `pay_id` int(250) NOT NULL AUTO_INCREMENT,
  `pay_date` date NOT NULL,
  `pay_value` decimal(10,2) NOT NULL,
  `pay_per_id` int(100) NOT NULL,
  `pay_trn_id` int(10) NOT NULL,
  PRIMARY KEY (`pay_id`),
  KEY `FK_payments_transactions_names` (`pay_trn_id`),
  KEY `FK_payments_persons` (`pay_per_id`),
  CONSTRAINT `FK_payments_persons` FOREIGN KEY (`pay_per_id`) REFERENCES `persons` (`per_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_payments_transactions_names` FOREIGN KEY (`pay_trn_id`) REFERENCES `transactions_names` (`trn_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.payments: ~3 rows (approximately)
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` (`pay_id`, `pay_date`, `pay_value`, `pay_per_id`, `pay_trn_id`) VALUES
	(1, '2013-06-20', 12.00, 4, 5),
	(2, '2013-06-20', 20.00, 3, 6),
	(6, '2013-06-20', 123.00, 2, 6);
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;


-- Dumping structure for table poss.persons
CREATE TABLE IF NOT EXISTS `persons` (
  `per_id` int(100) NOT NULL AUTO_INCREMENT,
  `per_name` varchar(250) NOT NULL,
  `per_address` varchar(200) DEFAULT NULL,
  `per_phone` varchar(100) DEFAULT NULL,
  `per_mobile` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`per_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.persons: ~5 rows (approximately)
/*!40000 ALTER TABLE `persons` DISABLE KEYS */;
INSERT INTO `persons` (`per_id`, `per_name`, `per_address`, `per_phone`, `per_mobile`) VALUES
	(1, 'Person1', '16farid', '7631', '011'),
	(2, 'Person2', '16 fariod elwy', '7631140', '012'),
	(3, 'Supplier2', 'HJHJH', '90990', '01144'),
	(4, 'customer1', 'kjll', '909090909', '01232'),
	(5, 'customer2', 'hsjdgh76', '7631140', '26783627');
/*!40000 ALTER TABLE `persons` ENABLE KEYS */;


-- Dumping structure for table poss.points
CREATE TABLE IF NOT EXISTS `points` (
  `pon_id` int(10) NOT NULL AUTO_INCREMENT,
  `pon_name` varchar(100) NOT NULL,
  PRIMARY KEY (`pon_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.points: ~2 rows (approximately)
/*!40000 ALTER TABLE `points` DISABLE KEYS */;
INSERT INTO `points` (`pon_id`, `pon_name`) VALUES
	(1, 'Point1'),
	(2, 'Point2');
/*!40000 ALTER TABLE `points` ENABLE KEYS */;


-- Dumping structure for table poss.products
CREATE TABLE IF NOT EXISTS `products` (
  `pro_id` int(10) NOT NULL AUTO_INCREMENT,
  `pro_cat_id` int(11) DEFAULT NULL,
  `pro_name` varchar(200) NOT NULL,
  `pro_sell` decimal(10,2) NOT NULL,
  PRIMARY KEY (`pro_id`),
  KEY `FK_products_categories` (`pro_cat_id`),
  CONSTRAINT `FK_products_categories` FOREIGN KEY (`pro_cat_id`) REFERENCES `categories` (`cat_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.products: ~5 rows (approximately)
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` (`pro_id`, `pro_cat_id`, `pro_name`, `pro_sell`) VALUES
	(5, 1, 'hard  500 GB SATA WD', 500.00),
	(6, 1, 'hard 320 GB SATA WD', 300.00),
	(8, 1, 'hard 750 GB SATA WD', 600.00),
	(9, 1, 'hard  500 GB SATA SEGATE', 200.00),
	(10, 1, 'hard 320 GB SATA SEGATE', 356.00);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;


-- Dumping structure for table poss.products_materials
CREATE TABLE IF NOT EXISTS `products_materials` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `material_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `unit` int(11) NOT NULL,
  `amount` smallint(2) NOT NULL COMMENT '0=kilo , 1=gram',
  PRIMARY KEY (`id`),
  KEY `FK_products_materials_materials` (`material_id`),
  KEY `FK_products_materials_products` (`product_id`),
  CONSTRAINT `FK_products_materials_materials` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_products_materials_products` FOREIGN KEY (`product_id`) REFERENCES `products` (`pro_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table poss.products_materials: ~0 rows (approximately)
/*!40000 ALTER TABLE `products_materials` DISABLE KEYS */;
/*!40000 ALTER TABLE `products_materials` ENABLE KEYS */;


-- Dumping structure for table poss.products_properties
CREATE TABLE IF NOT EXISTS `products_properties` (
  `psp_id` int(10) NOT NULL AUTO_INCREMENT,
  `psp_pro_id` int(10) NOT NULL,
  `psp_prp_id` int(10) NOT NULL,
  `psp_value` varchar(250) NOT NULL,
  PRIMARY KEY (`psp_id`),
  KEY `FK_products_properties_products` (`psp_pro_id`),
  KEY `FK_products_properties_properties` (`psp_prp_id`),
  CONSTRAINT `FK_products_properties_products` FOREIGN KEY (`psp_pro_id`) REFERENCES `products` (`pro_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_products_properties_properties` FOREIGN KEY (`psp_prp_id`) REFERENCES `properties` (`prp_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.products_properties: ~15 rows (approximately)
/*!40000 ALTER TABLE `products_properties` DISABLE KEYS */;
INSERT INTO `products_properties` (`psp_id`, `psp_pro_id`, `psp_prp_id`, `psp_value`) VALUES
	(7, 5, 4, ' 500 GB'),
	(8, 5, 5, 'SATA'),
	(9, 5, 3, 'WD'),
	(10, 6, 4, '320 GB'),
	(11, 6, 5, 'SATA'),
	(12, 6, 3, 'WD'),
	(13, 8, 4, '750 GB'),
	(14, 8, 5, 'SATA'),
	(15, 8, 3, 'WD'),
	(16, 9, 4, ' 500 GB'),
	(17, 9, 5, 'SATA'),
	(18, 9, 3, 'SEGATE'),
	(19, 10, 4, '320 GB'),
	(20, 10, 5, 'SATA'),
	(21, 10, 3, 'SEGATE');
/*!40000 ALTER TABLE `products_properties` ENABLE KEYS */;


-- Dumping structure for table poss.properties
CREATE TABLE IF NOT EXISTS `properties` (
  `prp_id` int(10) NOT NULL AUTO_INCREMENT,
  `prp_name` varchar(50) NOT NULL,
  `prp_cat_id` int(10) DEFAULT NULL,
  PRIMARY KEY (`prp_id`),
  KEY `FK_Properties_categories` (`prp_cat_id`),
  CONSTRAINT `FK_Properties_categories` FOREIGN KEY (`prp_cat_id`) REFERENCES `categories` (`cat_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.properties: ~8 rows (approximately)
/*!40000 ALTER TABLE `properties` DISABLE KEYS */;
INSERT INTO `properties` (`prp_id`, `prp_name`, `prp_cat_id`) VALUES
	(3, 'mark', NULL),
	(4, 'capacity', 1),
	(5, 'Socket', 1),
	(6, 'Chipset', 2),
	(7, 'Model', 2),
	(8, 'Type', 2),
	(9, 'Capacity', 3),
	(10, 'Type', 3);
/*!40000 ALTER TABLE `properties` ENABLE KEYS */;


-- Dumping structure for table poss.sell
CREATE TABLE IF NOT EXISTS `sell` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `date` date NOT NULL,
  `paid` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_sell_customers` (`customer_id`),
  CONSTRAINT `FK_sell_customers` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`cus_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table poss.sell: ~0 rows (approximately)
/*!40000 ALTER TABLE `sell` DISABLE KEYS */;
/*!40000 ALTER TABLE `sell` ENABLE KEYS */;


-- Dumping structure for table poss.sell_damaged
CREATE TABLE IF NOT EXISTS `sell_damaged` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `amount` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_sell_damaged_products` (`product_id`),
  CONSTRAINT `FK_sell_damaged_products` FOREIGN KEY (`product_id`) REFERENCES `products` (`pro_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table poss.sell_damaged: ~0 rows (approximately)
/*!40000 ALTER TABLE `sell_damaged` DISABLE KEYS */;
/*!40000 ALTER TABLE `sell_damaged` ENABLE KEYS */;


-- Dumping structure for table poss.sell_details
CREATE TABLE IF NOT EXISTS `sell_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sell_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `sell_price` decimal(10,2) NOT NULL,
  `amount` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_sell_details_sell` (`sell_id`),
  KEY `FK_sell_details_products` (`product_id`),
  CONSTRAINT `FK_sell_details_products` FOREIGN KEY (`product_id`) REFERENCES `products` (`pro_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_sell_details_sell` FOREIGN KEY (`sell_id`) REFERENCES `sell` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table poss.sell_details: ~0 rows (approximately)
/*!40000 ALTER TABLE `sell_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `sell_details` ENABLE KEYS */;


-- Dumping structure for table poss.stock
CREATE TABLE IF NOT EXISTS `stock` (
  `stk_id` int(250) NOT NULL AUTO_INCREMENT,
  `stk_material_id` int(11) NOT NULL,
  `stk_amount` int(10) NOT NULL,
  PRIMARY KEY (`stk_id`),
  KEY `FK_stock_materials` (`stk_material_id`),
  CONSTRAINT `FK_stock_materials` FOREIGN KEY (`stk_material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table poss.stock: ~0 rows (approximately)
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;


-- Dumping structure for table poss.suppliers
CREATE TABLE IF NOT EXISTS `suppliers` (
  `sup_id` int(10) NOT NULL AUTO_INCREMENT,
  `sup_per_id` int(10) NOT NULL,
  `sup_balance` decimal(10,2) NOT NULL,
  PRIMARY KEY (`sup_id`),
  KEY `FK_suppliers_persons` (`sup_per_id`),
  CONSTRAINT `FK_suppliers_persons` FOREIGN KEY (`sup_per_id`) REFERENCES `persons` (`per_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.suppliers: ~2 rows (approximately)
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` (`sup_id`, `sup_per_id`, `sup_balance`) VALUES
	(1, 2, 123.00),
	(2, 3, 120.00);
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;


-- Dumping structure for table poss.transactions
CREATE TABLE IF NOT EXISTS `transactions` (
  `trs_id` int(250) NOT NULL AUTO_INCREMENT,
  `trs_trn_id` int(10) NOT NULL,
  `trs_no` int(10) NOT NULL,
  `trs_date` date NOT NULL,
  `trs_ID_1` int(250) DEFAULT NULL,
  `trs_ID_2` int(250) DEFAULT NULL,
  `trs_total` decimal(10,2) NOT NULL,
  `trs_paid` decimal(10,2) NOT NULL,
  PRIMARY KEY (`trs_id`),
  KEY `FK_trsactions_transactions_names` (`trs_trn_id`),
  CONSTRAINT `FK_trsactions_transactions_names` FOREIGN KEY (`trs_trn_id`) REFERENCES `transactions_names` (`trn_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.transactions: ~3 rows (approximately)
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` (`trs_id`, `trs_trn_id`, `trs_no`, `trs_date`, `trs_ID_1`, `trs_ID_2`, `trs_total`, `trs_paid`) VALUES
	(2, 5, 14040001, '2014-04-13', NULL, NULL, 2324.00, 2324.00),
	(3, 5, 14040002, '2014-04-13', NULL, NULL, 3000.00, 3000.00),
	(4, 5, 14040003, '2014-04-13', NULL, NULL, 356.00, 356.00);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;


-- Dumping structure for table poss.transactions_details
CREATE TABLE IF NOT EXISTS `transactions_details` (
  `trd_id` int(250) NOT NULL AUTO_INCREMENT,
  `trd_trs_id` int(250) NOT NULL,
  `trd_pro_id` int(10) NOT NULL,
  `trd_amount` int(10) NOT NULL,
  `trd_price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`trd_id`),
  KEY `FK_transaction_detail_transactions` (`trd_trs_id`),
  KEY `FK_transaction_detail_product` (`trd_pro_id`),
  CONSTRAINT `FK_transaction_detail_product` FOREIGN KEY (`trd_pro_id`) REFERENCES `products` (`pro_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_transaction_detail_transactions` FOREIGN KEY (`trd_trs_id`) REFERENCES `transactions_names` (`trn_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.transactions_details: ~4 rows (approximately)
/*!40000 ALTER TABLE `transactions_details` DISABLE KEYS */;
INSERT INTO `transactions_details` (`trd_id`, `trd_trs_id`, `trd_pro_id`, `trd_amount`, `trd_price`) VALUES
	(2, 2, 6, 3, 300.00),
	(3, 2, 10, 4, 356.00),
	(4, 3, 6, 10, 300.00),
	(5, 4, 10, 1, 356.00);
/*!40000 ALTER TABLE `transactions_details` ENABLE KEYS */;


-- Dumping structure for table poss.transactions_names
CREATE TABLE IF NOT EXISTS `transactions_names` (
  `trn_id` int(10) NOT NULL AUTO_INCREMENT,
  `trn_name` varchar(200) NOT NULL,
  PRIMARY KEY (`trn_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- Dumping data for table poss.transactions_names: ~11 rows (approximately)
/*!40000 ALTER TABLE `transactions_names` DISABLE KEYS */;
INSERT INTO `transactions_names` (`trn_id`, `trn_name`) VALUES
	(1, 'لف هديا'),
	(2, 'مرتجع لف هدايا'),
	(3, 'حوافز عمل'),
	(4, 'خصومات عمل'),
	(5, 'قسط عميل'),
	(6, 'قسط لمورد'),
	(7, 'عمليه بيع فاتوره'),
	(8, 'عمليه مرتجع فاتوره بيع'),
	(9, 'عمليه شراء بضاعه'),
	(10, 'عمليه مرتجع بضاعه'),
	(11, 'هالك');
/*!40000 ALTER TABLE `transactions_names` ENABLE KEYS */;


-- Dumping structure for table poss.users
CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(10) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(30) NOT NULL,
  `user_pass` varchar(20) NOT NULL,
  `user_grp_id` int(1) DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_name` (`user_name`),
  KEY `FK_users_group` (`user_grp_id`),
  CONSTRAINT `FK_users_group` FOREIGN KEY (`user_grp_id`) REFERENCES `groups` (`grp_id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table poss.users: ~0 rows (approximately)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
