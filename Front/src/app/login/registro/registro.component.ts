import { Component } from '@angular/core';
import { Login } from 'src/app/Interfaces/login';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from 'src/app/services/login.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.scss']
})
export class RegistroComponent {

  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private _loginservice: LoginService, private router: Router
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

  registro() {
    this.loginData.userName = this.loginForm.get('userName')?.value
    this.loginData.password = this.loginForm.get('password')?.value

    if (this.loginForm.valid) {
      this._loginservice.registro(this.loginData).subscribe({
        next: data => {
          let dataUser: any = data

          if (dataUser.status === true) {
            console.log(dataUser);
            Swal.fire({
              icon: 'success',
              text: 'Bienvenido al sistema',
              showConfirmButton: false,
              timer: 2000,
              timerProgressBar: true,
              willClose: () => {
                this.router.navigate(['/login'])
              }
            });

          } else {
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: `${dataUser.message}`,
              showConfirmButton: false,
              timer: 2000,
              timerProgressBar: true
            });
          }
        }, error: error => {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: `${error.message}`,
            showConfirmButton: false,
            timer: 2000,
            timerProgressBar: true
          });
        }

      })
    }
  }

}
