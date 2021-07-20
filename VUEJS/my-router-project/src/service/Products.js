import axios from 'axios';

const url = "http://apigate.somee.com/a/"
export default class ProductService {
    getProductsId(id) {
        return axios.get(url + 'PublicAPI/GetProductsDeatils/' + id + '')
            .then(res => res.data)
            .catch(error => {
                console.log(error)
            });
    }
    
    getProductsCategory(id) {
        return axios.get(url + 'PublicAPI/GetProductsCT/'+id+'')
            .then(res => res.data)
            .catch(error => {
                console.log(error)
            });
    }

    getPcandPD(id) {
        return axios.get(url + 'PublicAPI/GetPhanTrang?productsCT='+id+'&priceMin=0&priceMax=0&size=&color=&type=0&numberpage=1')
            .then(res => res.data)
            .catch(error => {
                console.log(error)
            });
    }


    getSC() {
        return axios.get(url + 'PublicAPI/GetAllColorAndSize')
            .then(res => res.data)
            .catch(error => {
                console.log(error)
            });
    }


    getPhanTrang(productsCT,priceMin, priceMax, size, color, typer, numberpage) {
        // return this.http.get<IMenuDesktop[]>(this.heroesUrl);
        return axios.get(url+'PublicAPI/GetPhanTrang?productsCT='+productsCT+'&priceMin='+priceMin+'&priceMax='+priceMax+'&size='+size+'&color='+color+'&type='+typer+'&numberpage='+numberpage+'')
        .then(res => res.data)
            .catch(error => {
                console.log(error)
            });
    }


}
