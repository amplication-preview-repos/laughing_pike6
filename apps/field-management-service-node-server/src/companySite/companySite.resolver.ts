import * as graphql from "@nestjs/graphql";
import { CompanySiteResolverBase } from "./base/companySite.resolver.base";
import { CompanySite } from "./base/CompanySite";
import { CompanySiteService } from "./companySite.service";

@graphql.Resolver(() => CompanySite)
export class CompanySiteResolver extends CompanySiteResolverBase {
  constructor(protected readonly service: CompanySiteService) {
    super(service);
  }
}
