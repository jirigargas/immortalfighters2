import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppendTokenInterceptor implements HttpInterceptor {

  constructor() {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    var state = localStorage.getItem("authenticationState") ?? "{}";
    var token = JSON.parse(state).token;
    if (token && token !== "") {
      request = request.clone({ setHeaders: { Authorization: `Bearer ${token}` } });
    }
    return next.handle(request);
  }
}

