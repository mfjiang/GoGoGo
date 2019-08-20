/**
 *  路由配置
 */

export default [
    {
        path: "/login",
        name: "login",
        meta: {
            hideInMenu: true
        },
        component: () => import("@/views/login/index.vue")
    },

    {
        path: "/",
        name: "main",
        redirect: "/home",
        meta: {
            hideInMenu: true
        },
        component: () => import("@/views/layout/index.vue"),
        children: [
            {
                path: "/home",
                name: "home",
                meta: {
                    title: "首页"
                },
                component: () => import("@/views/home/index.vue")
            }
        ]
    }
];
