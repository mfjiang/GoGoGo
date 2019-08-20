<template>
	<el-menu
		:default-openeds="opendMenus"
		:default-active="currentActived"
		background-color="#545c64"
		text-color="#fff"
		active-text-color="#ffd04b"
		@select="handleMenuSelect"
	>
		<template v-for="(item, index) in data">
			<template v-if="item.children && item.children.length > 0">
				<el-submenu :index="item.name" :key="item.name">
					<template slot="title">
						<i class="el-icon-message"></i>
						{{item.title}}
					</template>
					<template v-for="(item2, index2) in item.children">
						<el-menu-item :index="item2.name" :key="item2.name">{{item2.title}}</el-menu-item>
					</template>
				</el-submenu>
			</template>
			<template v-else>
				<el-menu-item :index="item.name" :key="item.name">
					<i class="el-icon-message"></i>
					{{item.title}}
				</el-menu-item>
			</template>
		</template>
	</el-menu>
</template>

<script>
	export default {
		name: "LeftMenu",
		props: {
			data: Array
		},
		data() {
			return {
				opendMenus: [],
				currentActived: ""
			};
		},
		mounted() {
			this.currentActived = this.$route.name;
		},
		methods: {
			handleMenuSelect(index, indexPath) {
				// console.log(index);
				this.$emit("menuSelect", index);
			}
		},
		watch: {}
	};
</script>

<style lang="less" scoped>
</style>