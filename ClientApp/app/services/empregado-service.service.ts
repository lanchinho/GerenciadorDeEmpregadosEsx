import { Http, Response } from "@angular/http";
import { Injectable, Inject } from "@angular/core";
//import 'rxjs/add/operator/map';
//import 'rxjs/add/operator/catch';
//import 'rxjs/add/operator/throw';
import { Observable } from "rxjs/RX";




@Injectable()
export class EmpregadoService {

    myUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myUrl = baseUrl;
    }

    getEmpregados() {
        return this._http.get(this.myUrl + 'api/Empregado/GetAll')
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    getEmpregadoById(id: number) {
        return this._http.get(this.myUrl + "api/Empregado/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveEmpregado(empregado) {
        return this._http.post(this.myUrl + 'api/Empregado/Create', empregado)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
    
}