/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-06-17 16:55:46
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for discussion
-- ----------------------------
DROP TABLE IF EXISTS `discussion`;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of discussion
-- ----------------------------
