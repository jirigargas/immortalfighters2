import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DrdCharacterDetailComponent } from './drd-character-detail/drd-character-detail.component';
import { CharactersComponent } from './characters.component';
import { MyCharactersComponent } from './my-characters/my-characters.component';

const routes: Routes = [{
  path: '', component: CharactersComponent, children: [
    { path: 'my', component: MyCharactersComponent },
    { path: '0/:id', component: DrdCharacterDetailComponent }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CharactersRoutingModule { }
