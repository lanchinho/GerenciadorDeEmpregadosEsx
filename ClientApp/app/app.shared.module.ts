import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

//TODO: refatorar, criar barrel ...
import { EmpregadoService } from './services/empregado-service.service';
import { ListEmpregadoComponent } from './components/empregado/list-empregado.component';
import { AddEmpregadoComponent } from './components/empregado/add-empregado.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,        
        HomeComponent,
        ListEmpregadoComponent,
        AddEmpregadoComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'lista-empregado', component: ListEmpregadoComponent },
            { path: 'cadastrar-empregado', component: AddEmpregadoComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        EmpregadoService
    ]
})
export class AppModuleShared {
}


