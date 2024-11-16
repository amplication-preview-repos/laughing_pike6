import * as graphql from "@nestjs/graphql";
import { FieldModelResolverBase } from "./base/fieldModel.resolver.base";
import { FieldModel } from "./base/FieldModel";
import { FieldModelService } from "./fieldModel.service";

@graphql.Resolver(() => FieldModel)
export class FieldModelResolver extends FieldModelResolverBase {
  constructor(protected readonly service: FieldModelService) {
    super(service);
  }
}
