import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', redirectTo: 'authentication', pathMatch: 'full' },
  { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
  { path: 'main', loadChildren: () => import('./main/main.module').then(m => m.MainModule) },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
