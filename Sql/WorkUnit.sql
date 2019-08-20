/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-06-19 15:28:13
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for workunit
-- ----------------------------
DROP TABLE IF EXISTS `workunit`;
CREATE TABLE `workunit` (
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of workunit
-- ----------------------------
