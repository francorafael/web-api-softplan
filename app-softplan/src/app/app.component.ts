import { Component, OnInit } from '@angular/core';
import { CodigoGithubService } from './providers/codigo-github/codigo-github.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { JurosCompostosService } from './providers/juros-compostos/juros-compostos.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public title = 'app-softplan';
  public urlGitHub = '';
  public formGroup = new FormGroup({});
  public resultado = '';

  constructor(
    private codigoHitHubService: CodigoGithubService,
    private jurosCompostosService: JurosCompostosService,
    private formBuilder: FormBuilder) {
    this.formGroup = this.formBuilder.group({
      valor: new FormControl('', { validators: [Validators.required, Validators.min(1)] }),
      meses: new FormControl('', { validators: [Validators.required, Validators.min(1)] })
    });
  }

  public ngOnInit() {
    this.obterCodigoGitHubService();
  }

  private obterCodigoGitHubService() {
    this.codigoHitHubService.obterShowMeCodeGitHub().subscribe(
      (res: any) => {
        this.urlGitHub = res;
      }
    );
  }

  public calcularJuros() {
    if (this.formGroup.valid) {
      this.jurosCompostosService.calcularJurosCompostos(this.formGroup.controls.valor.value, this.formGroup.controls.meses.value).subscribe(
        (res: any) => {
          this.resultado = res.data.jurosCompostosCalculadoFormatoBrasil;
        }
      );
    }
  }

  public resetForm() {
    this.formGroup.reset();
    this.resultado = '';
  }
}
