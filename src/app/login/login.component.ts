import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../services/login.service';
import { Login } from '../Interfaces/login';
import { Router } from '@angular/router';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private _loginservice: LoginService, private router: Router, private alerta: MatSnackBar
  ) {
    this.loginForm = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }


  ngOnInit() {

  }

  loginData: Login = {
    userName: "",
    password: ""
  }

  login() {
    this.loginData.userName = this.loginForm.get('userName')?.value
    this.loginData.password = this.loginForm.get('password')?.value

    if (this.loginForm.valid) {
      this._loginservice.login(this.loginData).subscribe(data => {

        let dataUser: any = data

        if (dataUser.status === true) {
          this.router.navigate(['/inicio'])

          localStorage.setItem('userId', dataUser.value.userId)
          localStorage.setItem('userName', dataUser.value.userName)

          console.log(dataUser);

        } else {
          this.abrirAlerta(`${dataUser.message}`, '')
        }

      })
    }
  }

  abrirAlerta(message: string, action: string) {
    const config = new MatSnackBarConfig(); 
    config.panelClass = ['alertaError']; 
    config.duration= 3000;

    this.alerta.open(message, action, config)
  }

}
