import { Component, OnInit } from "@angular/core/";
import { Http } from "@angular/http";
import { Router } from "@angular/router";
import { EmpregadoService } from "../../services/empregado-service.service";


@Component({
    selector: 'listempregados',
    templateUrl: './list-empregado.component.html'

})
export class ListEmpregadoComponent implements OnInit {
    
    public empList: IEmpregado[]

    constructor(public http: Http, private _router: Router, private empregadoService: EmpregadoService) {
    }

    ngOnInit(){
        this.empregadoService.getEmpregados().subscribe(
            data => this.empList = data
        )
    }    
}