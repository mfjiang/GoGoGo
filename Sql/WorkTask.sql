/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-06-19 15:27:57
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for worktask
-- ----------------------------
DROP TABLE IF EXISTS `worktask`;
CREATE TABLE `worktask` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `workunit_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `creator_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `principal_id` bigint(20) NOT NULL DEFAULT '0',
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of worktask
-- ----------------------------
