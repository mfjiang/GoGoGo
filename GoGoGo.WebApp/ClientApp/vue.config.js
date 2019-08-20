module.exports = {
    lintOnSave: false,
    productionSourceMap: false,
    devServer: {
        proxy: "http://localhost:32734/"
    }
};
