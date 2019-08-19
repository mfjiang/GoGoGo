import Vue from "vue";
import Router from "vue-router";
import routes from "./config";
import store from "../store";

import { getToken, setToken } from "@/libs/";
import { getUserInfo } from "@/api/login";

Vue.use(Router);

const router = new Router({
    // mode: "history",
    routes: routes
});

router.beforeEach((to, from, next) => {
    next();

    // var token = getToken();
    // if (!token && to.name !== "login") {
    //     next({ name: "login" });
    // } else if (!token && to.name === "login") {
    //     next();
    // } else if (token && to.name === "login") {
    //     next({ name: "home" });
    // } else {
    //     if (store.state.hasUserInfo) next();
    //     else {
    //         getUserInfo()
    //             .then(result => {
    //                 next();
    //             })
    //             .catch(err => {
    //                 setToken("");
    //                 next({ name: "login" });
    //             });
    //     }
    // }
});

export default router;
