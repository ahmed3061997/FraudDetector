function api() {

    const instance = axios.create({
        headers: {
            'x-requested-with': 'XMLHttpRequest'
        },
    });
    instance.interceptors.request.use(
        (req) => {
            return req
        },
        (error) => {
            return Promise.reject(error);
        }
    );
    instance.interceptors.response.use(
        (res) => {
            return res;
        },
        async (err) => {
            hideLoading();
            const originalConfig = err.config;
            if (originalConfig.url !== "/auth/login" && err.response) {
                // Access Token was expired
                if (err.response.status === 401) {
                    //localStorage.removeItem('access-token');
                    //if (originalConfig._retry || originalConfig.url == "/auth/refresh-token") {
                    //    window.location = '/Settings/Users/Login';
                    //} else {
                    //    originalConfig._retry = true;
                    //    try {
                    //        debugger;
                    //        const rs = await instance.post("/auth/refresh-token", { token: getCookie('refresh-token') });
                    //        const { token } = rs.data.value;
                    //        localStorage.setItem('access-token', token);
                    //        return instance(originalConfig);
                    //    } catch (_error) {
                    //        return Promise.reject(_error);
                    //    }
                    //}
                } else {

                    var { errors } = err.response.data;
                    showToast('', errors?.join('<br>') || 'Undefined Error!', 'danger');

                }

            } else {

                var { errors } = err.response.data;
                showToast('', errors?.join('<br>') || 'Undefined Error!', 'danger');

            }
            return Promise.reject(err);
        }
    );
    return instance;
}