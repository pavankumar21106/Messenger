import { TestBed } from '@angular/core/testing';

import { PreventRedirectGuard } from './prevent-redirect.guard';

describe('PreventRedirectGuard', () => {
  let guard: PreventRedirectGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(PreventRedirectGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
