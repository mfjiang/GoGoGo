/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-06-19 15:26:49
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for landmark
-- ----------------------------
DROP TABLE IF EXISTS `landmark`;
CREATE TABLE `landmark` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` bigint(20) unsigned NOT NULL,
  `deadline` datetime DEFAULT NULL,
  `title` varchar(255) NOT NULL,
  `remark` text,
  `state` int(3) DEFAULT '0',
  `finish_date` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of landmark
-- ----------------------------
