/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-06-17 16:56:24
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for productfeature
-- ----------------------------
DROP TABLE IF EXISTS `productfeature`;
CREATE TABLE `productfeature` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `product_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `module_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `creator_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `last_editor_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `title` varchar(255) NOT NULL,
  `remark` text NOT NULL,
  `level` int(4) NOT NULL DEFAULT '0',
  `state` int(4) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of productfeature
-- ----------------------------
