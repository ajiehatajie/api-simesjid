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

/*Table structure for table `mst_access` */

DROP TABLE IF EXISTS `mst_access`;

CREATE TABLE `mst_access` (
  `access_id` int(100) NOT NULL AUTO_INCREMENT,
  `access_roleid` varchar(100) DEFAULT NULL,
  `access_userid` varchar(100) DEFAULT NULL,
  `access_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`access_id`),
  KEY `f_userid_ac` (`access_userid`),
  CONSTRAINT `f_userid_ac` FOREIGN KEY (`access_userid`) REFERENCES `mst_users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_access` */

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
  PRIMARY KEY (`category_id`),
  KEY `f_userid_cat` (`category_userid`),
  KEY `f_userid_catsub` (`category_parentid`),
  CONSTRAINT `f_userid_cat` FOREIGN KEY (`category_userid`) REFERENCES `mst_users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `f_userid_catsub` FOREIGN KEY (`category_parentid`) REFERENCES `mst_categories` (`category_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_categories` */

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
  PRIMARY KEY (`setting_id`),
  KEY `f_userid_set` (`setting_created_by`),
  CONSTRAINT `f_userid_set` FOREIGN KEY (`setting_created_by`) REFERENCES `mst_users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_settings` */

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
  UNIQUE KEY `email` (`user_email`),
  KEY `f_user` (`user_parentid`),
  CONSTRAINT `f_user` FOREIGN KEY (`user_parentid`) REFERENCES `mst_users` (`user_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mst_users` */

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
  `expense_settingid` varchar(100) DEFAULT NULL,
  `expense_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `expense_updated` datetime DEFAULT NULL,
  `expense_created_by` varchar(100) DEFAULT NULL,
  `expense_updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`expense_id`),
  KEY `userid` (`expense_created_by`),
  KEY `date` (`expense_date`) USING BTREE,
  CONSTRAINT `userid` FOREIGN KEY (`expense_created_by`) REFERENCES `mst_users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE
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
  `income_settingid` varchar(100) DEFAULT NULL,
  `income_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `income_updated` datetime DEFAULT NULL,
  `income_created_by` varchar(100) DEFAULT NULL,
  `income_updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`income_id`),
  KEY `f_userid` (`income_created_by`),
  CONSTRAINT `f_userid` FOREIGN KEY (`income_created_by`) REFERENCES `mst_users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE
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
