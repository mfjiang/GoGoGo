-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: 127.0.0.1    Database: GoGoGo
-- ------------------------------------------------------
-- Server version	5.6.38

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `aglie_project`
--

DROP TABLE IF EXISTS `aglie_project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aglie_project` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `creator_id` bigint(20) unsigned DEFAULT '0',
  `last_editor_id` bigint(20) unsigned DEFAULT '0',
  `chife_manager_id` bigint(20) unsigned DEFAULT '0',
  `executor_id` bigint(20) unsigned DEFAULT '0',
  `remark` text,
  `level` int(10) DEFAULT '0',
  `state` int(10) DEFAULT '0',
  `start_date` datetime DEFAULT NULL,
  `finish_date` datetime DEFAULT NULL,
  `last_updated` datetime DEFAULT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `discussion`
--

DROP TABLE IF EXISTS `discussion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `discussion` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `reply_to` bigint(20) unsigned NOT NULL DEFAULT '0',
  `sender_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `sender_name` varchar(255) NOT NULL,
  `product_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `module_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `feature_id` bigint(20) unsigned NOT NULL,
  `issues_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `task_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `test_record_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `content` text NOT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `issues`
--

DROP TABLE IF EXISTS `issues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `issues` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `product_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `creator_id` bigint(20) unsigned NOT NULL,
  `last_editor_id` bigint(20) NOT NULL DEFAULT '0',
  `from_who` varchar(255) NOT NULL DEFAULT 'unknown',
  `title` varchar(255) NOT NULL,
  `remark` text NOT NULL,
  `level` int(4) NOT NULL DEFAULT '0',
  `state` int(4) NOT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `product_type` int(10) DEFAULT '0',
  `code` varchar(255) DEFAULT NULL,
  `name` varchar(255) NOT NULL,
  `remark` text,
  `main_ver` varchar(255) NOT NULL,
  `source_uri` varchar(500) DEFAULT NULL,
  `open_api_uri` varchar(500) DEFAULT NULL,
  `creator_id` bigint(20) unsigned DEFAULT '0',
  `last_editor_id` bigint(20) unsigned DEFAULT '0',
  `level` int(10) DEFAULT '0',
  `state` int(10) DEFAULT '0',
  `last_updated` datetime DEFAULT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `product_feature`
--

DROP TABLE IF EXISTS `product_feature`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_feature` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `product_id` bigint(20) unsigned DEFAULT '0',
  `module_id` bigint(20) unsigned DEFAULT '0',
  `creator_id` bigint(20) unsigned DEFAULT '0',
  `last_editor_id` bigint(20) unsigned DEFAULT '0',
  `title` varchar(255) NOT NULL,
  `remark` text,
  `level` int(10) DEFAULT '0',
  `state` int(10) DEFAULT '0',
  `last_updated` datetime DEFAULT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `product_module`
--

DROP TABLE IF EXISTS `product_module`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_module` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `module_code` varchar(255) DEFAULT NULL,
  `creator_id` bigint(20) unsigned DEFAULT '0',
  `last_editor_id` bigint(20) unsigned DEFAULT '0',
  `version_id` bigint(20) unsigned DEFAULT '0',
  `parent_id` bigint(20) unsigned DEFAULT '0',
  `product_id` bigint(20) unsigned DEFAULT '0',
  `title` varchar(255) NOT NULL,
  `remark` text,
  `level` int(10) DEFAULT '0',
  `state` int(10) DEFAULT '0',
  `last_updated` datetime DEFAULT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `roadmap`
--

DROP TABLE IF EXISTS `roadmap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roadmap` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` bigint(20) unsigned NOT NULL,
  `deadline` datetime DEFAULT NULL,
  `title` varchar(255) NOT NULL,
  `remark` text,
  `state` int(3) DEFAULT '0',
  `finish_date` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usecase`
--

DROP TABLE IF EXISTS `usecase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usecase` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `product_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `module_id` bigint(20) NOT NULL,
  `creator_id` bigint(20) unsigned NOT NULL,
  `last_editor_id` bigint(20) NOT NULL DEFAULT '0',
  `test_path` varchar(255) DEFAULT NULL,
  `remark` text,
  `paramas` text,
  `expected_results` text NOT NULL,
  `tested_results` text NOT NULL,
  `quality_pass` bit(1) NOT NULL DEFAULT b'0',
  `state` int(4) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` int(20) unsigned NOT NULL,
  `mobile_no` varchar(25) DEFAULT NULL,
  `wx_uuid` varchar(50) DEFAULT NULL,
  `wx_name` varchar(50) DEFAULT NULL,
  `wx_avata_url` varchar(100) DEFAULT NULL,
  `nick_name` varchar(255) NOT NULL,
  `real_name` varchar(255) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `pwd` varchar(100) NOT NULL,
  `work_groups` varchar(255) DEFAULT NULL,
  `roles` varchar(255) DEFAULT NULL,
  `employee_no` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `is_banned` bit(1) DEFAULT b'0',
  `last_login_date` datetime DEFAULT NULL,
  `last_session_id` varchar(100) DEFAULT NULL,
  `last_login_ip` varchar(50) DEFAULT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user_group`
--

DROP TABLE IF EXISTS `user_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_group` (
  `group_name` varchar(255) NOT NULL,
  `users` varchar(255) DEFAULT NULL,
  `creator_id` bigint(20) DEFAULT '0',
  `created` datetime NOT NULL,
  PRIMARY KEY (`group_name`),
  UNIQUE KEY `id_UNIQUE` (`group_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `work_task`
--

DROP TABLE IF EXISTS `work_task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `work_task` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `workunit_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `creator_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `executor_id` bigint(20) NOT NULL DEFAULT '0',
  `task_type` int(4) NOT NULL DEFAULT '0',
  `title` varchar(255) NOT NULL,
  `confirm_state` int(4) NOT NULL DEFAULT '0',
  `review_state` int(4) NOT NULL,
  `confirm_by_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `review_by_id` bigint(20) NOT NULL,
  `level` int(4) NOT NULL DEFAULT '0',
  `state` int(4) NOT NULL DEFAULT '0',
  `close_time` datetime DEFAULT NULL,
  `confirm_time` datetime DEFAULT NULL,
  `review_time` datetime DEFAULT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `work_unit`
--

DROP TABLE IF EXISTS `work_unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `work_unit` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` bigint(20) NOT NULL DEFAULT '0',
  `parent_id` bigint(20) NOT NULL DEFAULT '0',
  `product_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `version_id` bigint(20) NOT NULL,
  `module_id` bigint(20) NOT NULL,
  `creator_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `executor_id` bigint(20) NOT NULL DEFAULT '0',
  `members` varchar(255) NOT NULL,
  `title` varchar(255) NOT NULL,
  `start_date` datetime DEFAULT NULL,
  `finish_date` datetime DEFAULT NULL,
  `level` int(4) NOT NULL DEFAULT '0',
  `state` int(4) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-09-27 17:20:55
