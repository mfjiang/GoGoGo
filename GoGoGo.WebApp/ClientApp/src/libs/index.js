import Cookie from "js-cookie";

/**
 *  TODO
 */
export const resolveMenuFromRoutes = routes => {
    function getMenus(route, result) {
        var menu = {
            name: route.name,
            title: route.meta && route.meta.title,
            children: []
        };

        if (route.children) {
            route.children
                .filter(item => item.meta && !item.meta["hideInMenu"])
                .forEach(item => {
                    getMenus(item, menu.children);
                });
        }

        result.push(menu);
    }

    var result = [];
    routes
        .filter(item => item.meta && !item.meta["hideInMenu"])
        .forEach(item => {
            getMenus(item, result);
        });

    return result;
};

export const getToken = () => {
    return Cookie.get(".token") || "";
};

export const setToken = token => {
    Cookie.set(".token", token);
};
