import axios from 'axios';

const url = "http://apigate.somee.com/a/"
export default class HomeService {

    getListProducts() {
        return axios.get(url + 'PublicAPI/GetProductsHome')
            .then(res => res.data)
            .catch(error => {
                console.log(error)
            });
    }
    getListArticle() {
        return axios.get(url + 'PublicAPI/GetArticle')
            .then(res => res.data)
            .catch(error => {
                console.log(error)
            });
    }
    getListArticleId(num) {
        return axios.get(url + 'PublicAPI/GetArticle?id='+num+'')
            .then(res => res.data)
            .catch(error => {
                console.log(error)
            });
      }
    getArticle(id) {
        return axios.get(url + 'PublicAPI/GetArticleId?id='+id+'')
            .then(res => res.data)
            .catch(error => {
                console.log(error)
            });
    }
    //PublicAPI/getMenuDesktop
    getMenu() {
        return axios.get(url + 'PublicAPI/getMenuDesktop')
            .then(res => res.data)
            .catch(error => {
                console.log(error)
            });
    }

}
