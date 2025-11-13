<!--
Sync Impact Report:
Version Change: 1.0.0 → 1.1.0
Modified Principles:
  - I. Component-Based Architecture: 强化前端严格类型要求
  - II. API-First Development: 明确后端仅提供 API，无视图渲染
  - V. Observability and Maintainability: 添加 TypeScript strict 模式要求
Added Sections:
  - Technology Stack Standards: 添加严格类型和现代化构建工具要求
Removed Sections: None
Templates Status:
  ✅ plan-template.md - aligned with updated principles
  ✅ spec-template.md - aligned with updated principles
  ✅ tasks-template.md - aligned with updated principles
  ✅ All command prompts - reviewed for generic guidance
Follow-up TODOs: None
-->

# CHSNS Constitution

## Core Principles

### I. Component-Based Architecture

All new features MUST be developed as modular, reusable components with clear boundaries:

- Frontend components (Vue 3 + Ant Design Vue) MUST be self-contained with props/emits contracts
- Frontend MUST use TypeScript with **strict mode enabled** (`strict: true` in tsconfig.json)
- All component props, emits, and composable returns MUST have explicit type definitions
- Backend services (.NET 10) MUST follow service-oriented architecture with dependency injection
- Backend MUST provide **ONLY APIs** - no view rendering, no server-side HTML generation
- Each component/service MUST have a single, well-defined responsibility
- Components MUST be independently testable without requiring full application context
- Legacy code in `Src/` folder is exempt but SHOULD be refactored when touched

**Rationale**: Modular architecture with strict typing catches errors at compile time, enables parallel development, easier testing, maintainability, and gradual migration from legacy codebase. Backend as pure API enables frontend flexibility and true separation of concerns.

### II. API-First Development

All frontend-backend communication MUST go through well-defined REST APIs:

- Backend serves **ONLY as API provider** - zero view rendering or HTML generation
- API contracts MUST be documented before implementation begins
- Use JSON for request/response payloads with consistent, typed structure
- RESTful conventions MUST be followed (GET/POST/PUT/DELETE, proper status codes)
- API versioning MUST be implemented for breaking changes (e.g., `/api/v1/`, `/api/v2/`)
- OpenAPI/Swagger documentation MUST be maintained and auto-generated for all endpoints
- Request/response DTOs MUST have explicit types on both frontend (TypeScript) and backend (C#)
- Frontend MUST handle all UI rendering, routing, and user interactions

**Rationale**: Pure API backend enables complete frontend/backend separation, allows frontend technology changes without backend impact, facilitates mobile app development, and ensures consistent data contracts through strong typing on both ends.

### III. Test-Driven Development (NON-NEGOTIABLE)

TDD cycle MUST be followed for all new code:

1. Write test cases based on acceptance criteria
2. Get user/stakeholder approval on test scenarios
3. Verify tests fail (RED phase)
4. Implement minimal code to pass tests (GREEN phase)
5. Refactor while keeping tests green (REFACTOR phase)

Tests are MANDATORY for:

- All new API endpoints (contract tests)
- Business logic and service layer (unit tests)
- Critical user journeys (integration tests)
- Vue components with complex logic (component tests)

**Rationale**: TDD ensures code correctness, prevents regressions, serves as living documentation, and builds confidence in refactoring legacy code.

### IV. Progressive Migration Strategy

Legacy code migration MUST follow these rules:

- Do NOT attempt big-bang rewrites
- When fixing bugs or adding features to legacy code, refactor that specific area
- New features MUST be built in `frontend/` and `backend/` directories using modern stack
- Legacy `Src/` code is read-only unless actively being migrated
- Document migration progress and maintain backward compatibility during transition
- Each migration increment MUST be independently deployable

**Rationale**: Gradual migration reduces risk, maintains business continuity, and allows learning from each increment.

### V. Observability and Maintainability

All code MUST support operational visibility and long-term maintenance:

- Structured logging MUST be used (with correlation IDs for request tracing)
- Error messages MUST be actionable and include context
- Performance-critical paths MUST be instrumented (e.g., API response times)
- Code MUST be documented: complex logic gets inline comments, public APIs get XML/JSDoc comments
- Configuration MUST be externalized (environment variables, config files)
- Follow consistent naming conventions: C# (PascalCase for public, camelCase for private), TypeScript (camelCase for variables/functions, PascalCase for types/interfaces/components)
- TypeScript MUST use strict mode (`strict: true`) with no `any` types except explicitly justified
- All TypeScript code MUST pass `eslint` and `tsc --noEmit` without errors

**Rationale**: Observable systems are debuggable in production; maintainable code reduces long-term costs and enables team scalability. Strict typing eliminates entire classes of runtime errors and serves as inline documentation.

## Technology Stack Standards

### Frontend Requirements (Modern Stack - NON-NEGOTIABLE)

- **Framework**: Vue 3 with Composition API (`<script setup>` syntax MANDATORY)
- **Type Safety**: TypeScript with **strict mode enabled** (`strict: true`, no `any` types)
- **UI Library**: Ant Design Vue 4.x (latest stable)
- **State Management**: Pinia (for complex state), provide/inject (for simple cases)
- **Build Tool**: Vite 5+ (modern, fast build tool)
- **Package Manager**: pnpm (fast, disk-efficient) or npm (consistent lock files required)
- **Testing**: Vitest (unit/component tests), Playwright (E2E tests)
- **Code Quality**:
  - ESLint with TypeScript rules (no warnings/errors allowed)
  - Prettier for formatting (consistent code style)
  - Husky + lint-staged for pre-commit hooks
- **Type Definitions**: All functions, components, and composables MUST have explicit return types
- **No Runtime Type Casting**: Avoid `as any` or `as unknown` - prefer type guards and proper typing

### Backend Requirements (API-Only Modern Stack)

- **Framework**: .NET 10 (ASP.NET Core Web API template, **NOT MVC**)
- **API Style**: RESTful with JSON payloads, OpenAPI/Swagger documentation
- **Architecture**: Clean Architecture or Vertical Slice Architecture
- **Database**: Entity Framework Core for data access (code-first approach)
- **Authentication**: JWT-based authentication with proper token management
- **Validation**: FluentValidation or Data Annotations for input validation
- **Testing**:
  - xUnit for unit tests
  - WebApplicationFactory for integration tests
  - Test coverage MUST be > 80% for business logic
- **Code Quality**:
  - .editorconfig for consistent formatting
  - Code analyzers enabled (StyleCop, Roslynator)
  - Nullable reference types enabled (`<Nullable>enable</Nullable>`)
- **Logging**: Structured logging with Serilog (JSON output)
- **API Documentation**: Swashbuckle/NSwag for auto-generated OpenAPI specs
- **No Views**: Backend MUST NOT contain Razor views, static file serving (except Swagger UI), or any HTML generation

### Development Environment (Modern Tooling)

- **Version Control**: Git with conventional commit messages (`feat:`, `fix:`, `docs:`, etc.)
- **Branching**: Feature branches from `main`, PR-based workflow with required reviews
- **CI/CD**:
  - GitHub Actions or Azure DevOps pipelines
  - Automated builds, tests, and linting on every PR
  - Automated deployment to staging/production
- **Docker**: Containerization for consistent development and deployment environments
- **Documentation**:
  - Markdown files in `docs/` directory
  - API documentation via OpenAPI/Swagger
  - Inline code comments for complex logic
  - Architecture Decision Records (ADRs) for major technical decisions

## Development Workflow

### Feature Development Process

1. **Specification Phase** (`/speckit.specify`):

   - Document user stories with acceptance criteria
   - Prioritize stories (P1, P2, P3)
   - Define API contracts if backend changes needed
   - Get stakeholder approval

2. **Planning Phase** (`/speckit.plan`):

   - Research technical approaches
   - Define data models and component structure
   - Create implementation plan with tasks
   - Review constitution compliance

3. **Implementation Phase** (`/speckit.tasks`):

   - Write tests first (TDD)
   - Implement in small, reviewable increments
   - Update documentation alongside code
   - Run tests continuously during development

4. **Review Phase**:
   - Code review checks: functionality, tests, constitution compliance
   - All tests MUST pass before merge
   - Documentation MUST be complete
   - Legacy code touched MUST be improved (not degraded)

### Quality Gates

Before merging to `main`:

- ✅ All automated tests pass (frontend & backend)
- ✅ TypeScript compilation successful with no errors (`tsc --noEmit`)
- ✅ ESLint passes with zero warnings/errors
- ✅ Backend code analysis passes with zero warnings
- ✅ Code review approved by at least one team member
- ✅ API documentation updated (OpenAPI/Swagger specs current)
- ✅ No new linting/formatting violations introduced
- ✅ Test coverage maintains or improves (minimum 80% for new code)
- ✅ Constitution principles verified (especially strict typing and API-only backend)
- ✅ Performance benchmarks pass (if applicable)

### Priority of Work

1. **P1 (Critical)**: Security fixes, data loss bugs, production outages
2. **P2 (High)**: User-facing bugs, essential features, technical debt blocking new work
3. **P3 (Normal)**: Feature enhancements, non-blocking improvements, refactoring
4. **P4 (Low)**: Nice-to-haves, optimizations, exploratory work

## Governance

### Authority and Compliance

- This constitution supersedes all other development practices and conventions
- All pull requests MUST be reviewed for constitution compliance
- Deviations from principles MUST be explicitly justified in PR descriptions
- Constitution violations without justification MUST be rejected

### Amendment Process

Constitution changes require:

1. Written proposal explaining rationale for change
2. Impact analysis on existing code and workflows
3. Team discussion and consensus
4. Version bump following semantic versioning:
   - **MAJOR**: Backward-incompatible principle changes or removals
   - **MINOR**: New principles added or material expansions
   - **PATCH**: Clarifications, wording improvements, non-semantic changes
5. Migration plan for affected code (if applicable)
6. Update of all dependent templates and documentation

### Complexity Justification

Any code or architecture that increases complexity MUST be justified by:

- Clear business value or technical necessity
- Documented alternatives considered and rejected
- Plan for maintaining the complexity over time
- Agreement that benefit outweighs maintenance cost

### Runtime Guidance

For day-to-day development guidance and AI agent instructions, refer to:

- `.specify/templates/` for command workflows
- `.github/prompts/speckit.*.prompt.md` for agent-specific instructions
- `docs/` directory for architecture decision records and guides

**Version**: 1.1.0 | **Ratified**: 2025-11-13 | **Last Amended**: 2025-11-13
