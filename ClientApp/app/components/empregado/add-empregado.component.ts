import { Component } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from "@angular/router";
import { EmpregadoService } from "../../services/empregado-service.service";


@Component({
    selector: 'addempregado',
    templateUrl: './add-empregado.component.html'
})
export class AddEmpregadoComponent {
    empregadoForm: FormGroup;
    id: number;
    errorMessage: any;

    constructor(private _formBuilder: FormBuilder, private _empregadoService: EmpregadoService, private _router: Router) {
        this.empregadoForm = this._formBuilder.group({
            id: 0,
            nome: ['', [Validators.required]],
            salarioBruto: ['', [Validators.required]],
            faixaImposto: ['', [Validators.required]]
        })
    }

    save() {
        if (!this.empregadoForm.valid) {
            return;
        }
        this._empregadoService.saveEmpregado(this.empregadoForm.value)
            .subscribe((data) => {
                this._router.navigate(['/lista-empregado']);
            }, error => this.errorMessage = error)
    }

    cancel() {
        this._router.navigate(['/lista-empregado']);
    }

    //TODO: Remover, talvez ?
    get name() { return this.empregadoForm.get('nome'); }
    get salarioBruto() { return this.empregadoForm.get('salarioBruto'); }
    get faixaImposto() { return this.empregadoForm.get('faixaImposto'); }    
}