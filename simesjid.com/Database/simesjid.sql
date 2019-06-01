/*
SQLyog Ultimate v11.11 (32 bit)
MySQL - 5.5.15 : Database - dev_simesjid
*********************************************************************
*/


/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`dev_simesjid` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `dev_simesjid`;

/*Table structure for table `log_hits` */

DROP TABLE IF EXISTS `log_hits`;

CREATE TABLE `log_hits` (
  `log_id` varchar(100) NOT NULL,
  `log_ua` text,
  `log_country` varchar(100) DEFAULT NULL,
  `log_source` varchar(100) DEFAULT NULL,
  `log_referer` varchar(100) DEFAULT NULL,
  `log_url` varchar(100) DEFAULT NULL,
  `log_ip` varchar(100) DEFAULT NULL,
  `log_os` varchar(100) DEFAULT NULL,
  `log_app_version` varchar(20) DEFAULT NULL,
  `log_app_name` varchar(100) DEFAULT NULL,
  `log_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `log_hits` */

/*Table structure for table `log_tokens` */

DROP TABLE IF EXISTS `log_tokens`;

CREATE TABLE `log_tokens` (
  `token_id` varchar(100) NOT NULL,
  `token_name` varchar(100) DEFAULT NULL,
  `token_userid` varchar(100) DEFAULT NULL,
  `token_revoked` varchar(2) DEFAULT NULL,
  `token_refresh` varchar(100) DEFAULT NULL,
  `token_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`token_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `log_tokens` */

insert  into `log_tokens`(`token_id`,`token_name`,`token_userid`,`token_revoked`,`token_refresh`,`token_created`) values ('02052a61-8bec-4768-91b8-3a1c73a6854b','sinta','sinta','0','sdOS7wtA1wOjA1hlcmVNeMVEuXy7KdIJrHwE1HOWRQo=','2019-05-24 10:49:46'),('02174399-d5c1-4110-afb1-772ef6e91f76','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','cbad9f58-d013-4005-93ec-cc8c8415e60f','2019-05-28 13:59:54'),('09048148-bae5-4eda-9d4c-f19f4e8695a1','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','3aa14cc4-3d68-4d87-a690-1824694bbc18','2019-06-01 12:13:35'),('29ebdce6-c08c-4525-b1ff-8e83aa1906e8','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','zOa3Fh/lLbCYR8OLFgvaOZZ0YFotIyvvyxH+LiFv6HU=','2019-05-24 11:00:14'),('2f7a659f-5760-48d7-b4cb-0b56f06d0c2a','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','b4c1627e-8676-4a7b-bfba-81d53568aaf4','2019-05-28 13:53:44'),('4a838b13-6daa-4c1e-980a-87d1efe47c23','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','a8de0dc2-1523-473a-bb49-255f90073c1a','2019-05-28 14:32:53'),('4e28a35e-ab26-42b0-9868-503a15a8e462','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','1e3d8291-eba7-4ad1-acea-172ab2f11df0','2019-05-24 14:09:00'),('561e94a2-d114-47e7-a28b-c05012aeb146','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','f3d36d91-8ab4-4b28-bd61-3587b7bfd3a4','2019-05-29 08:33:16'),('6ea3b87a-9419-4944-a1d8-b2b22aed54d9','bambang@gmail.com','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','0','4b6d04e0-3b1c-48ec-90e0-687a38d7de1a','2019-06-01 13:59:43'),('849341fe-6150-49fe-b7df-19b15251205c','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','a4dc59af-1f7f-46dd-af36-ed290e457683','2019-05-28 14:57:10'),('c8446bbc-a6f5-47c9-ade2-c36b6145c357','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','b6ec1f0c-9cfc-4272-9028-b8d2e3c42c85','2019-05-28 13:35:00'),('cf5beb81-e70e-4745-83b9-61bf7443eb5a','sinta','sinta','0','3LWUcKReGMYQyWURkdMNKZsozAgC/B1RervuDJtPiYc=','2019-05-24 10:37:41'),('d0b06fd4-12a1-4101-ba9b-e1bf4ccd4a29','sinta','sinta','0','lYjzco1biIWs8YAw2XZV1hxNMcqIt4q83GqBrP2kpQI=','2019-05-24 10:57:53'),('d8916be6-c077-4056-8c23-66fd62fa2c53','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','4d13cc58-7817-474d-aa7f-e3bbd4a5e026','2019-05-28 14:57:38'),('dcad7f5f-fc0c-4c15-a070-4c344b4f9255','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','99a638a5-4676-40e8-8990-669937c0a630','2019-05-24 11:24:52'),('ed704673-6946-4220-a72f-db042534b19d','sinta','f2b36670-9b3c-48b3-90bc-476ac1b08bee','0','4ecb9296-5cdb-4829-ad5d-a557b4086bce','2019-05-28 13:28:42');

/*Table structure for table `mst_access` */

DROP TABLE IF EXISTS `mst_access`;

CREATE TABLE `mst_access` (
  `access_id` int(100) NOT NULL AUTO_INCREMENT,
  `access_roleid` varchar(100) DEFAULT NULL,
  `access_userid` varchar(100) DEFAULT NULL,
  `access_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`access_id`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=latin1;

/*Data for the table `mst_access` */

insert  into `mst_access`(`access_id`,`access_roleid`,`access_userid`,`access_created`) values (1,'1','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-06-01 11:18:32'),(2,'2','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-06-01 11:21:12'),(3,'3','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-06-01 11:21:15'),(4,'4','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-06-01 11:21:20'),(5,'1','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(6,'2','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(7,'3','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(8,'4','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(9,'5','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(10,'6','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(11,'7','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(12,'8','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(13,'9','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(14,'10','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(15,'11','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(16,'12','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(17,'13','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(18,'14','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(19,'15','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(20,'16','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(21,'17','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(22,'18','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(23,'19','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 13:32:32'),(36,'1','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(37,'2','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(38,'3','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(39,'4','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(40,'5','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(41,'6','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(42,'7','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(43,'8','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(44,'9','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(45,'10','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(46,'11','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(47,'12','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(48,'13','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(49,'14','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(50,'15','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(51,'16','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(52,'17','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(53,'18','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46'),(54,'19','1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','2019-06-01 15:43:46');

/*Table structure for table `mst_accounts` */

DROP TABLE IF EXISTS `mst_accounts`;

CREATE TABLE `mst_accounts` (
  `account_id` varchar(100) DEFAULT NULL,
  `account_name` varchar(100) DEFAULT NULL,
  `account_balance` double DEFAULT NULL,
  `account_desc` text,
  `account_userid` varchar(100) DEFAULT NULL,
  `account_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_accounts` */

insert  into `mst_accounts`(`account_id`,`account_name`,`account_balance`,`account_desc`,`account_userid`,`account_created`) values ('0494f143-c28a-4f42-9aaa-816f56b82877','CASH',100,'Account untuk Uang Cash','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-21 11:10:59'),('d4b56bcb-addf-4742-89af-7f6828ade844','BANK JABAR',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:34:19'),('2a1e2a5f-2993-462d-802d-2650f7a569f3','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:23'),('91d797c6-840c-4938-b957-384510dcf661','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:23'),('dae79fd6-61d1-4154-969b-648aca9fe921','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:24'),('6364372d-a41d-460d-91a9-af3016e6779f','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:25'),('dabc63e7-8dbc-45c1-8616-c3d9e5c82d94','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:26'),('c62f2453-68cf-4ad0-b92b-c41d809dde5d','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:26'),('5591eb16-ac0d-4ced-8313-743b370da311','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:27'),('bda4715e-3232-4679-8a50-19097c7f0e06','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:27'),('af00fc4f-3730-495f-b4a0-3bdaf0ee08e5','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:28'),('0480e6b5-d117-4941-9e9e-8fd7d9f90ae0','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:29'),('c05a4095-8beb-49d5-8871-9b637bc01a5e','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:29'),('fe79d671-1baa-430b-ab4d-7c00a01813b7','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:30'),('d0fcb8c2-bdaa-4945-aa8e-86c202ba9eb5','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:30'),('72b2ebb2-c153-4644-82b2-51013bda5b36','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:31'),('c3e25028-77ea-4dcd-8714-aecc1afc3119','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:32'),('d306f28d-0a6b-432e-a781-0bc7798e4ff6','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:32'),('baae18ce-62f4-4e93-bb10-f77ff8232d6a','AD',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 15:35:33'),('8d0cdad4-ae43-4e2c-bb58-a72f4c90e747','CREDIT',100000,'Account untuk Uang BANK JABAR','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-05-22 16:46:36'),('2f740682-7b0c-4b9a-b17d-61565797779e','REKENING BANK',10000,'Rekening Bank BJB','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 14:01:56'),('3ebd278d-9255-49aa-bc76-dd47a6d62b88','CASH',10000,'Uang Cash','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 14:10:15');

/*Table structure for table `mst_categories` */

DROP TABLE IF EXISTS `mst_categories`;

CREATE TABLE `mst_categories` (
  `category_id` varchar(200) NOT NULL,
  `category_name` varchar(100) DEFAULT NULL,
  `category_desc` text,
  `category_userid` varchar(100) DEFAULT NULL,
  `category_type` varchar(10) DEFAULT NULL,
  `category_color` varchar(20) DEFAULT NULL,
  `category_parentid` varchar(100) DEFAULT NULL,
  `category_created` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_categories` */

insert  into `mst_categories`(`category_id`,`category_name`,`category_desc`,`category_userid`,`category_type`,`category_color`,`category_parentid`,`category_created`) values ('462e2edc-9a6d-41b5-b9d0-62a366e70494','Zakat Mal',NULL,'f2b36670-9b3c-48b3-90bc-476ac1b08bee','income','#2ecc71','z2b36670-9b3c-48b3-90bc-476ac1b08b1e','2019-05-29 11:16:36'),('78761e21-7033-47db-908d-593c897cd73e','Zakat Mal',NULL,'f2b36670-9b3c-48b3-90bc-476ac1b08bee','income',NULL,NULL,'2019-05-29 08:58:55'),('c043efc8-58ef-454d-ad3f-f7c0de9ea2e6','Keropak Jumat',NULL,'f2b36670-9b3c-48b3-90bc-476ac1b08bee','income','#2ecc71','z2b36670-9b3c-48b3-90bc-476ac1b08b1e','2019-05-29 11:30:45'),('z2b36670-9b3c-48b3-90bc-476ac1b08b1e','Infaq',NULL,'f2b36670-9b3c-48b3-90bc-476ac1b08bee','income',NULL,NULL,'2019-05-29 09:03:48');

/*Table structure for table `mst_global_setup` */

DROP TABLE IF EXISTS `mst_global_setup`;

CREATE TABLE `mst_global_setup` (
  `param_id` varchar(20) DEFAULT NULL,
  `param_code` varchar(50) DEFAULT NULL,
  `param_name` varchar(100) DEFAULT NULL,
  `param_value` varchar(100) DEFAULT NULL,
  `param_number_value` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_global_setup` */

insert  into `mst_global_setup`(`param_id`,`param_code`,`param_name`,`param_value`,`param_number_value`) values ('FORMAT_NO','JP','','JP.Y2.M2.D2.X8','0'),('COUNTER','JP',NULL,NULL,'5'),('APP','DAY',NULL,NULL,'24'),('APP','MONTH',NULL,NULL,'5'),('APP','YEAR',NULL,NULL,'2019');

/*Table structure for table `mst_pictures` */

DROP TABLE IF EXISTS `mst_pictures`;

CREATE TABLE `mst_pictures` (
  `picture_id` varchar(100) NOT NULL,
  `picture_filename` varchar(100) DEFAULT NULL,
  `picture_path` varchar(100) DEFAULT NULL,
  `picture_created_by` varchar(100) DEFAULT NULL,
  `picture_created` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`picture_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_pictures` */

/*Table structure for table `mst_roles` */

DROP TABLE IF EXISTS `mst_roles`;

CREATE TABLE `mst_roles` (
  `role_id` int(10) NOT NULL,
  `role_name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_roles` */

insert  into `mst_roles`(`role_id`,`role_name`) values (1,'Transactions'),(2,'Income'),(3,'Expense'),(4,'Accounts'),(5,'Track Budget'),(6,'Set Goals'),(7,'Calendar'),(8,'Income Category'),(9,'Expense Category'),(10,'Income Reports'),(11,'Expense Category'),(12,'Income vs Expense Reports'),(13,'Income Monthly Report'),(14,'Expense Monthly Report'),(15,'Account Transaction Reports'),(16,'User Role'),(17,'Application Setting'),(18,'Upcoming Income'),(19,'Upcoming Expense');

/*Table structure for table `mst_settings` */

DROP TABLE IF EXISTS `mst_settings`;

CREATE TABLE `mst_settings` (
  `setting_id` varchar(100) NOT NULL,
  `setting_mosque_name` varchar(100) DEFAULT NULL,
  `setting_countries` varchar(100) DEFAULT NULL,
  `setting_city` varchar(100) DEFAULT NULL,
  `setting_web` varchar(100) DEFAULT NULL,
  `setting_phone` varchar(50) DEFAULT NULL,
  `setting_mosque_email` varchar(50) DEFAULT NULL,
  `setting_currency` varchar(10) DEFAULT NULL,
  `setting_address` text,
  `setting_languange` varchar(20) DEFAULT NULL,
  `setting_logo` varchar(100) DEFAULT NULL,
  `setting_geolocation` varchar(200) DEFAULT NULL,
  `setting_created` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `setting_updated` datetime DEFAULT NULL,
  `setting_created_by` varchar(100) DEFAULT NULL,
  `setting_updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`setting_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_settings` */

insert  into `mst_settings`(`setting_id`,`setting_mosque_name`,`setting_countries`,`setting_city`,`setting_web`,`setting_phone`,`setting_mosque_email`,`setting_currency`,`setting_address`,`setting_languange`,`setting_logo`,`setting_geolocation`,`setting_created`,`setting_updated`,`setting_created_by`,`setting_updated_by`) values ('3e2cdf0c-7342-419a-809f-6bff953a4827','Masjid Al-Amin',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2019-06-01 15:43:46',NULL,'1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41',NULL),('9862f9ca-7e5d-4bcb-b69e-bd730b3de553','Masjid Syuhada',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2019-06-01 13:32:23',NULL,'80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd',NULL),('9a9cf56a-884f-4b8f-a32b-a8ca8fdd0064',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2019-05-21 10:19:44',NULL,'f2b36670-9b3c-48b3-90bc-476ac1b08bee',NULL);

/*Table structure for table `mst_tree` */

DROP TABLE IF EXISTS `mst_tree`;

CREATE TABLE `mst_tree` (
  `tree_id` varchar(100) NOT NULL,
  `tree_userid` varchar(100) NOT NULL,
  `tree_jobposition` varchar(100) DEFAULT NULL,
  `tree_parentid` varchar(100) DEFAULT NULL,
  `tree_settingid` varchar(100) NOT NULL,
  `tree_created_by` varchar(100) DEFAULT NULL,
  `tree_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`tree_id`),
  KEY `parentid` (`tree_parentid`),
  CONSTRAINT `parentid` FOREIGN KEY (`tree_parentid`) REFERENCES `mst_tree` (`tree_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_tree` */

insert  into `mst_tree`(`tree_id`,`tree_userid`,`tree_jobposition`,`tree_parentid`,`tree_settingid`,`tree_created_by`,`tree_created`) values ('00c8e4fe-e0cf-48dd-a9b9-c22c6370dds','00c8e4fe-e0cf-48dd-a9b9-c22c6370dff5','BENDARAHA','80d7ab28-0c9b-4970-96cf-9d7cb2aa3a','9862f9ca-7e5d-4bcb-b69e-bd730b3de553','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 15:29:47'),('80d7ab28-0c9b-4970-96cf-9d7cb2aa3a','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','KETUA DKM',NULL,'9862f9ca-7e5d-4bcb-b69e-bd730b3de553','80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','2019-06-01 15:29:49'),('f2b36670-9b3c-48b3-90bc-476ac1b08bee','f2b36670-9b3c-48b3-90bc-476ac1b08bee','BENDARA 2','80d7ab28-0c9b-4970-96cf-9d7cb2aa3a','9862f9ca-7e5d-4bcb-b69e-bd730b3de553','f2b36670-9b3c-48b3-90bc-476ac1b08bee','2019-06-01 15:29:51');

/*Table structure for table `mst_users` */

DROP TABLE IF EXISTS `mst_users`;

CREATE TABLE `mst_users` (
  `user_id` varchar(100) NOT NULL,
  `user_name` varchar(100) DEFAULT NULL,
  `user_email` varchar(100) DEFAULT NULL,
  `user_password` varchar(100) DEFAULT NULL,
  `user_lastname` varchar(100) DEFAULT NULL,
  `user_role` enum('admin','staff') DEFAULT 'staff',
  `user_parentid` varchar(100) DEFAULT NULL,
  `user_phone` varchar(100) DEFAULT NULL,
  `user_status` varchar(10) DEFAULT NULL,
  `user_email_verified_at` datetime DEFAULT NULL,
  `user_token` varchar(100) DEFAULT NULL,
  `user_remember_token` varchar(100) DEFAULT NULL,
  `user_created` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `user_updated` datetime DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `email` (`user_email`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_users` */

insert  into `mst_users`(`user_id`,`user_name`,`user_email`,`user_password`,`user_lastname`,`user_role`,`user_parentid`,`user_phone`,`user_status`,`user_email_verified_at`,`user_token`,`user_remember_token`,`user_created`,`user_updated`) values ('00c8e4fe-e0cf-48dd-a9b9-c22c6370dff5','Jaka Sembun','jaka@gmail.com','$2b$10$e5pnGT5Asfwavxybp3TakePL.nyA5aEOm6VXuBz4V3Jz3GpjazJ.W',NULL,'staff',NULL,NULL,NULL,NULL,NULL,NULL,'2019-06-01 14:29:50',NULL),('1cfe3df9-f9e4-4930-9ed9-01f0d6b58a41','Didin Suma','didin@gmail.com','$2b$10$4IkgpaEkayR9NhZ/7LbNy.UVMJ/7A0Pf4zJBLcmZz6d31Scp.iAbW',NULL,'staff',NULL,NULL,NULL,NULL,NULL,NULL,'2019-06-01 15:43:46',NULL),('6bcd6a1b-ae0a-4e2f-9c23-d660aa376e26','ajie','hatajie@gmail.com','$2b$10$ozx79l1Fm26k.G9Dx9szVenrm72sFVsw92u28MKK9DwQkJzOoQ56y','hatajie','staff',NULL,NULL,NULL,NULL,NULL,NULL,'2019-05-20 16:42:21',NULL),('80d7ab28-0c9b-4970-96cf-9d7cb2aa38dd','Bambang Sumantri','bambang@gmail.com','$2b$10$zxhlj0hfMvwoQ1BBRx.cJ.h/sINLnTIe4QpNeSLfWOrXYvkbMxOZ6',NULL,'staff',NULL,NULL,NULL,NULL,'4b6d04e0-3b1c-48ec-90e0-687a38d7de1a',NULL,'2019-06-01 13:32:13',NULL),('f2b36670-9b3c-48b3-90bc-476ac1b08bee','sinta','sin@gmail.com','$2b$10$BbY9KG8QXi6mDMwI6qi6I.Kvxj9acRsMQe9sencfHyGuHF6eITRWK','hatajie','staff',NULL,NULL,NULL,NULL,'3aa14cc4-3d68-4d87-a690-1824694bbc18',NULL,'2019-05-21 10:19:35',NULL);

/*Table structure for table `report_daily` */

DROP TABLE IF EXISTS `report_daily`;

CREATE TABLE `report_daily` (
  `report_id` varchar(100) NOT NULL,
  `report_settingid` varchar(100) DEFAULT NULL,
  `report_expense` double DEFAULT NULL,
  `report_income` double DEFAULT NULL,
  `report_note` text,
  `report_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`report_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `report_daily` */

/*Table structure for table `trx_expenses` */

DROP TABLE IF EXISTS `trx_expenses`;

CREATE TABLE `trx_expenses` (
  `expense_id` varchar(100) NOT NULL,
  `expense_name` varchar(100) DEFAULT NULL,
  `expense_amount` double DEFAULT NULL,
  `expense_ref` varchar(100) DEFAULT NULL,
  `expense_date` date DEFAULT NULL,
  `expense_accountid` varchar(100) DEFAULT NULL,
  `expense_categoryid` varchar(100) DEFAULT NULL,
  `expense_subcategoryid` varchar(100) DEFAULT NULL,
  `expense_note` text,
  `expense_pictureid` varchar(100) DEFAULT NULL,
  `expense_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `expense_updated` datetime DEFAULT NULL,
  `expense_created_by` varchar(100) DEFAULT NULL,
  `expense_updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`expense_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trx_expenses` */

/*Table structure for table `trx_incomes` */

DROP TABLE IF EXISTS `trx_incomes`;

CREATE TABLE `trx_incomes` (
  `income_id` varchar(100) NOT NULL,
  `income_name` varchar(100) DEFAULT NULL,
  `income_amount` double DEFAULT NULL,
  `income_ref` varchar(100) DEFAULT NULL,
  `income_date` date DEFAULT NULL,
  `income_accountid` varchar(100) DEFAULT NULL,
  `income_categoryid` varchar(100) DEFAULT NULL,
  `income_subcategoryid` varchar(100) DEFAULT NULL,
  `income_note` text,
  `income_pictureid` varchar(100) DEFAULT NULL,
  `income_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `income_updated` datetime DEFAULT NULL,
  `income_created_by` varchar(100) DEFAULT NULL,
  `income_updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`income_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trx_incomes` */

/*Table structure for table `vi_role_users` */

DROP TABLE IF EXISTS `vi_role_users`;

/*!50001 DROP VIEW IF EXISTS `vi_role_users` */;
/*!50001 DROP TABLE IF EXISTS `vi_role_users` */;

/*!50001 CREATE TABLE  `vi_role_users`(
 `role_name` varchar(100) ,
 `role_userid` varchar(100) 
)*/;

/*Table structure for table `vi_subcategory` */

DROP TABLE IF EXISTS `vi_subcategory`;

/*!50001 DROP VIEW IF EXISTS `vi_subcategory` */;
/*!50001 DROP TABLE IF EXISTS `vi_subcategory` */;

/*!50001 CREATE TABLE  `vi_subcategory`(
 `parent_id` varchar(200) ,
 `parent_name` varchar(100) ,
 `category_type` varchar(10) ,
 `category_id` varchar(200) ,
 `category_name` varchar(100) ,
 `category_desc` text ,
 `category_userid` varchar(100) ,
 `category_created` timestamp 
)*/;

/*Table structure for table `vi_tree` */

DROP TABLE IF EXISTS `vi_tree`;

/*!50001 DROP VIEW IF EXISTS `vi_tree` */;
/*!50001 DROP TABLE IF EXISTS `vi_tree` */;

/*!50001 CREATE TABLE  `vi_tree`(
 `tree_id` varchar(100) ,
 `tree_parentid` varchar(100) ,
 `tree_jobposition` varchar(100) ,
 `user_name` varchar(100) ,
 `tree_settingid` varchar(100) 
)*/;

/*View structure for view vi_role_users */

/*!50001 DROP TABLE IF EXISTS `vi_role_users` */;
/*!50001 DROP VIEW IF EXISTS `vi_role_users` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vi_role_users` AS select `c`.`role_name` AS `role_name`,`b`.`access_userid` AS `role_userid` from ((`mst_users` `a` join `mst_access` `b` on((`a`.`user_id` = `b`.`access_userid`))) join `mst_roles` `c` on((`b`.`access_roleid` = `c`.`role_id`))) */;

/*View structure for view vi_subcategory */

/*!50001 DROP TABLE IF EXISTS `vi_subcategory` */;
/*!50001 DROP VIEW IF EXISTS `vi_subcategory` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vi_subcategory` AS select `a`.`category_id` AS `parent_id`,`a`.`category_name` AS `parent_name`,`a`.`category_type` AS `category_type`,`b`.`category_id` AS `category_id`,`b`.`category_name` AS `category_name`,`b`.`category_desc` AS `category_desc`,`b`.`category_userid` AS `category_userid`,`b`.`category_created` AS `category_created` from (`mst_categories` `a` join `mst_categories` `b` on((`a`.`category_id` = `b`.`category_parentid`))) where isnull(`a`.`category_parentid`) order by `b`.`category_name` */;

/*View structure for view vi_tree */

/*!50001 DROP TABLE IF EXISTS `vi_tree` */;
/*!50001 DROP VIEW IF EXISTS `vi_tree` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vi_tree` AS select `a`.`tree_id` AS `tree_id`,`a`.`tree_parentid` AS `tree_parentid`,`a`.`tree_jobposition` AS `tree_jobposition`,`b`.`user_name` AS `user_name`,`a`.`tree_settingid` AS `tree_settingid` from ((`mst_tree` `a` join `mst_users` `b` on((`a`.`tree_userid` = `b`.`user_id`))) left join `mst_tree` `c` on((`a`.`tree_id` = `c`.`tree_parentid`))) order by `a`.`tree_parentid` */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
