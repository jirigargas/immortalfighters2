import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Role } from '../../core/models/role-models';
import { ForumApiService } from '../../core/services/forum-api.service';
import { RoleApiService } from '../../core/services/role-api.service';
import { InvalidStateMatcher } from '../../shared/invalid-state-matcher';

@Component({
  selector: 'app-create-forum',
  templateUrl: './create-forum.component.html',
  styleUrls: ['./create-forum.component.scss']
})
export class CreateForumComponent implements OnInit {

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    category: new FormControl('', [Validators.required]),
    roles: new FormArray([])
  });

  matcher = new InvalidStateMatcher();
  categories$: Observable<string[]>;

  constructor(private dialogRef: MatDialogRef<CreateForumComponent>,
    private forumApi: ForumApiService,
    private roleApi: RoleApiService,
    private formBuilder: FormBuilder) {
    this.categories$ = this.forumApi.getAllCategories();

    this.roleApi.getAll()
      .pipe(
        tap(roles => {
          var formArray = this.form.get('roles') as FormArray;
          roles.forEach(role => {
            formArray.push(this.createRoleFormItem(role));
          });
        })
      )
      .subscribe();
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.form.valid) {
      this.dialogRef.close(this.form.value);
    }
  }

  createRoleFormItem(role: Role): FormGroup {
    return this.formBuilder.group({
      roleId: role.roleId,
      name: role.name,
      canRead: '',
      canWrite: ''
    });
  }

  getRoleControls(): AbstractControl[] {
    var roleArray = <FormArray>this.form.get('roles');
    return roleArray.controls;
  }

  getRoleName(index: number) {
    var roleArray = <FormArray>this.form.get('roles');
    var roleGroup = <FormGroup>roleArray.controls[index];
    return roleGroup.get('name')?.value;
  }
}
