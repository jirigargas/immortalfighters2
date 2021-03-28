import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CharactersComponent } from './characters.component';
import { MyCharactersComponent } from './my-characters/my-characters.component';

const routes: Routes = [{
  path: '', component: CharactersComponent, children: [
    { path: 'my', component: MyCharactersComponent }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CharactersRoutingModule { }
