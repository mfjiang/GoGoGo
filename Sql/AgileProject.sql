/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-06-19 15:26:18
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for agileproject
-- ----------------------------
DROP TABLE IF EXISTS `agileproject`;
CREATE TABLE `agileproject` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `creator_id` bigint(20) NOT NULL,
  `chife_manager_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `executor_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `level` int(3) DEFAULT '0',
  `state` int(3) DEFAULT NULL,
  `start_date` datetime DEFAULT NULL,
  `finish_date` datetime DEFAULT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of agileproject
-- ----------------------------
