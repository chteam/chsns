# Feature Specification: 用户认证与授权系统

**Feature Branch**: `001-user-auth-system`  
**Created**: 2025-11-13  
**Status**: Draft  
**Input**: 用户认证与授权系统：用户注册、登录、密码管理、JWT认证、OAuth2第三方登录集成、会话管理

## User Scenarios & Testing *(mandatory)*

### User Story 1 - 用户注册 (Priority: P1)

新用户访问网站时需要创建账户才能使用社交功能。用户提供基本信息（用户名、密码、可选邮箱），系统验证后创建账户。

**Why this priority**: 这是整个应用的入口，没有账户用户无法使用任何功能。注册必须简单快速，降低用户流失率。

**Independent Test**: 可以通过访问注册页面，填写表单，成功创建账户并自动登录来独立测试。验证数据库中账户已创建。

**Acceptance Scenarios**:

1. **Given** 用户访问注册页面, **When** 输入有效的用户名（4-32字符）和密码（4-32字符）, **Then** 系统创建账户并自动登录用户
2. **Given** 用户尝试注册, **When** 输入的用户名已被使用, **Then** 系统显示"用户名已存在"错误提示
3. **Given** 用户在注册页面, **When** 输入用户名后离开输入框, **Then** 系统实时检查用户名可用性并显示提示
4. **Given** 用户提交注册表单, **When** 用户名或密码不符合长度要求（4-32字符）, **Then** 系统显示格式错误提示
5. **Given** 用户可选填写邮箱, **When** 邮箱格式无效, **Then** 系统显示邮箱格式错误

---

### User Story 2 - 用户登录与注销 (Priority: P1)

已注册用户需要通过用户名和密码登录系统来访问个人内容和社交功能。用户可以随时注销退出登录状态。

**Why this priority**: 用户需要安全地访问自己的账户和数据。登录是用户回访的必经之路，体验必须流畅。

**Independent Test**: 可以通过访问登录页面，输入已注册的用户名和密码，验证登录成功并跳转到用户主页。注销后无法访问需要认证的页面。

**Acceptance Scenarios**:

1. **Given** 已注册用户访问登录页面, **When** 输入正确的用户名和密码, **Then** 系统验证成功并跳转到用户主页
2. **Given** 用户尝试登录, **When** 输入错误的密码, **Then** 系统显示"用户名或密码错误"提示（不透露具体是哪个错误）
3. **Given** 用户尝试登录, **When** 用户名不存在, **Then** 系统显示"用户名或密码错误"提示
4. **Given** 已登录用户, **When** 点击注销按钮, **Then** 系统清除登录状态并跳转到首页
5. **Given** 已注销用户, **When** 尝试访问需要认证的页面, **Then** 系统重定向到登录页面
6. **Given** 用户登录成功, **When** 系统生成会话令牌, **Then** 后续请求携带令牌进行身份验证

---

### User Story 3 - OAuth2 第三方登录 (Priority: P1)

用户可以通过第三方账号（如 GitHub、Google、微信、QQ）快速登录，无需记住额外的用户名密码。首次使用第三方登录时自动创建账户。

**Why this priority**: 降低注册门槛，提升用户体验。很多用户不愿意创建新账户，第三方登录可以显著提高注册转化率。

**Independent Test**: 可以通过点击"使用 GitHub 登录"按钮，完成 OAuth2 授权流程，验证账户创建或登录成功。

**Acceptance Scenarios**:

1. **Given** 用户在登录页面, **When** 点击"使用 GitHub 登录"按钮, **Then** 系统跳转到 GitHub 授权页面
2. **Given** 用户授权 GitHub 访问, **When** 授权成功返回, **Then** 系统获取用户信息并创建或关联账户
3. **Given** 首次使用 GitHub 登录, **When** 授权完成, **Then** 系统自动创建账户并使用 GitHub 用户名作为默认用户名
4. **Given** 已存在的用户通过 GitHub 登录, **When** GitHub 账号已绑定, **Then** 系统直接登录到已绑定的账户
5. **Given** 用户使用多个第三方账号, **When** 都绑定到同一账户, **Then** 用户可以通过任意已绑定的第三方账号登录
6. **Given** OAuth2 授权失败或用户取消, **When** 返回登录页面, **Then** 系统显示"第三方登录失败"提示

---

### User Story 4 - 密码重置 (Priority: P2)

用户忘记密码时需要能够重置密码。系统通过邮箱验证用户身份后允许设置新密码。

**Why this priority**: 虽然不是核心注册流程，但密码重置是常见需求。没有此功能会导致用户永久失去账户访问权限。

**Independent Test**: 可以通过"忘记密码"链接，输入邮箱接收重置链接，使用链接设置新密码并登录验证。

**Acceptance Scenarios**:

1. **Given** 用户点击"忘记密码"链接, **When** 输入注册时的邮箱, **Then** 系统发送密码重置链接到邮箱
2. **Given** 用户收到重置邮件, **When** 点击邮件中的重置链接, **Then** 系统显示密码重置表单
3. **Given** 用户在重置表单中, **When** 输入新密码（4-32字符）并确认, **Then** 系统更新密码并自动登录
4. **Given** 密码重置链接, **When** 链接过期（超过24小时）, **Then** 系统显示"链接已过期，请重新申请"
5. **Given** 用户请求重置密码, **When** 输入的邮箱未注册, **Then** 系统显示"如果该邮箱存在，将收到重置邮件"（不透露邮箱是否存在）
6. **Given** 用户频繁请求密码重置, **When** 超过频率限制（5分钟内3次）, **Then** 系统显示"请求过于频繁，请稍后再试"

---

### User Story 5 - 修改密码 (Priority: P2)

已登录用户可以在账户设置中修改密码。用户需要输入当前密码验证身份后才能设置新密码。

**Why this priority**: 安全最佳实践要求定期更换密码。用户也可能因为安全原因主动更改密码。

**Independent Test**: 可以通过访问账户设置页面，输入当前密码和新密码，验证密码更新后可以使用新密码登录。

**Acceptance Scenarios**:

1. **Given** 已登录用户在账户设置页面, **When** 输入当前密码和新密码, **Then** 系统验证当前密码正确后更新密码
2. **Given** 用户尝试修改密码, **When** 当前密码输入错误, **Then** 系统显示"当前密码错误"提示
3. **Given** 用户输入新密码, **When** 新密码与当前密码相同, **Then** 系统显示"新密码不能与当前密码相同"
4. **Given** 用户修改密码成功, **When** 密码更新完成, **Then** 系统在其他设备的会话保持有效（可选：或强制重新登录）
5. **Given** 用户修改密码, **When** 新密码不符合安全要求, **Then** 系统显示密码强度提示（建议但不强制）

---

### User Story 6 - 会话管理与安全 (Priority: P2)

系统需要管理用户会话，支持"记住我"功能，并在安全事件发生时能够撤销会话。

**Why this priority**: 良好的会话管理提升用户体验（免于频繁登录），同时保障账户安全（可撤销异常会话）。

**Independent Test**: 可以通过测试"记住我"功能在浏览器关闭后保持登录状态，以及在账户设置中查看和撤销活跃会话。

**Acceptance Scenarios**:

1. **Given** 用户登录时勾选"记住我", **When** 关闭浏览器重新打开, **Then** 用户仍保持登录状态
2. **Given** 用户登录时未勾选"记住我", **When** 关闭浏览器重新打开, **Then** 用户需要重新登录
3. **Given** 已登录用户, **When** 30天内无活动, **Then** 系统自动注销会话（"记住我"可延长到90天）
4. **Given** 用户在账户设置中, **When** 查看"活跃会话"列表, **Then** 系统显示所有活跃会话（设备、位置、最后活动时间）
5. **Given** 用户发现可疑会话, **When** 点击"注销"按钮, **Then** 系统撤销该会话并通知用户
6. **Given** 用户修改密码或进行敏感操作, **When** 操作完成, **Then** 系统可选地注销其他设备的会话（可配置）

---

### Edge Cases

- **并发注册**: 两个用户同时尝试注册相同用户名，系统必须确保只有一个成功
- **会话劫持**: 恶意用户尝试使用窃取的令牌，系统应检测异常（如 IP 突变、User-Agent 变化）
- **暴力破解**: 用户或机器人频繁尝试登录，系统应启用速率限制和验证码
- **OAuth2 失败**: 第三方服务不可用或返回错误，系统应优雅降级并提示用户
- **邮件发送失败**: SMTP 服务异常导致密码重置邮件无法发送，系统应记录错误并稍后重试
- **令牌过期**: 用户正在操作时令牌过期，系统应提示重新登录而不是报错
- **账户锁定**: 用户多次登录失败后账户被临时锁定（如10分钟），防止暴力破解
- **数据库不可用**: 认证服务依赖数据库，数据库故障时应返回友好错误而不是系统崩溃

## Requirements *(mandatory)*

### Functional Requirements

#### 注册与账户创建
- **FR-001**: 系统 MUST 允许用户通过用户名和密码注册账户
- **FR-002**: 用户名 MUST 符合格式：4-32个字符，支持字母、数字、中文、下划线
- **FR-003**: 密码 MUST 符合格式：4-32个字符，支持任意可见字符
- **FR-004**: 系统 MUST 实时验证用户名可用性（AJAX 检查）
- **FR-005**: 系统 MUST 防止用户名重复，注册时进行唯一性校验
- **FR-006**: 邮箱为可选字段，如果提供则 MUST 验证邮箱格式有效性
- **FR-007**: 注册成功后系统 MUST 自动登录用户并跳转到用户主页

#### 登录与认证
- **FR-008**: 系统 MUST 支持用户名 + 密码登录
- **FR-009**: 密码验证失败时 MUST 显示通用错误信息（不区分用户名或密码错误）
- **FR-010**: 系统 MUST 使用 JWT (JSON Web Token) 作为认证令牌
- **FR-011**: JWT 令牌 MUST 包含用户 ID、用户名、过期时间
- **FR-012**: JWT 令牌默认有效期为 24 小时，"记住我"模式下为 30 天
- **FR-013**: 系统 MUST 在每次 API 请求中验证 JWT 令牌有效性
- **FR-014**: 令牌过期后 MUST 返回 401 状态码并提示重新登录
- **FR-015**: 用户可以选择"记住我"选项延长会话有效期

#### OAuth2 第三方登录
- **FR-016**: 系统 MUST 支持 OAuth2.0 标准协议集成第三方登录
- **FR-017**: 系统 MUST 支持至少以下提供商：GitHub, Google, Microsoft
- **FR-018**: 系统 SHOULD 支持中国常用提供商：微信、QQ、微博（可扩展）
- **FR-019**: 首次使用第三方登录时 MUST 自动创建本地账户
- **FR-020**: 系统 MUST 存储第三方提供商 ID 和用户 ID 的映射关系
- **FR-021**: 用户可以绑定多个第三方账号到同一本地账户
- **FR-022**: OAuth2 回调 MUST 验证 state 参数防止 CSRF 攻击
- **FR-023**: 第三方登录失败时 MUST 显示友好错误信息并允许重试

#### 密码管理
- **FR-024**: 系统 MUST 使用加密哈希算法存储密码（推荐 bcrypt 或 Argon2）
- **FR-025**: 密码 MUST 加盐（salt）后存储，每个用户使用唯一盐值
- **FR-026**: 系统 MUST 提供"忘记密码"功能通过邮箱重置密码
- **FR-027**: 密码重置链接 MUST 包含随机令牌，有效期 24 小时
- **FR-028**: 密码重置令牌使用后 MUST 立即失效
- **FR-029**: 已登录用户 MUST 能够在账户设置中修改密码
- **FR-030**: 修改密码时 MUST 验证当前密码正确性
- **FR-031**: 系统 SHOULD 提供密码强度提示但不强制复杂度要求

#### 会话管理
- **FR-032**: 系统 MUST 记录用户登录时间和最后活动时间
- **FR-033**: 用户闲置超过 30 天后会话 MUST 自动过期
- **FR-034**: 用户可以在账户设置中查看所有活跃会话
- **FR-035**: 用户可以注销指定会话或注销所有其他会话
- **FR-036**: 修改密码后系统 SHOULD 提供选项注销其他设备会话
- **FR-037**: 系统 MUST 记录登录历史（时间、IP、设备信息）供安全审计

#### 安全与防护
- **FR-038**: 系统 MUST 实施登录速率限制：同一 IP 5 分钟内最多 5 次尝试
- **FR-039**: 登录失败 5 次后账户 MUST 临时锁定 10 分钟
- **FR-040**: 系统 MUST 记录所有认证相关的安全事件（登录、注销、密码修改等）
- **FR-041**: 敏感操作（修改密码、绑定第三方账号）MUST 验证用户身份
- **FR-042**: 系统 MUST 防止 CSRF 攻击（使用 Anti-CSRF Token）
- **FR-043**: 系统 MUST 使用 HTTPS 传输所有认证相关数据
- **FR-044**: 密码重置请求频率 MUST 限制为 5 分钟内最多 3 次

### Key Entities

#### Account (账户实体)
- **UserId** (long, 主键): 用户唯一标识
- **UserName** (string, 50字符, 唯一): 用户登录名
- **Password** (string, 哈希后存储): 加密后的密码
- **Email** (string, 可选): 用户邮箱
- **PasswordSalt** (string): 密码加盐值
- **Code** (long, 可选): 邀请码或验证码
- **CreatedAt** (DateTime): 账户创建时间
- **UpdatedAt** (DateTime): 账户更新时间

#### UserSession (用户会话)
- **SessionId** (Guid, 主键): 会话唯一标识
- **UserId** (long, 外键): 关联用户
- **Token** (string): JWT 令牌（或令牌哈希）
- **DeviceInfo** (string): 设备信息（User-Agent）
- **IpAddress** (string): 登录 IP 地址
- **CreatedAt** (DateTime): 会话创建时间
- **LastActivityAt** (DateTime): 最后活动时间
- **ExpiresAt** (DateTime): 过期时间
- **IsRevoked** (bool): 是否已撤销

#### ExternalLogin (第三方登录绑定)
- **Id** (long, 主键): 绑定记录 ID
- **UserId** (long, 外键): 关联本地用户
- **Provider** (string): 提供商名称（GitHub, Google, WeChat 等）
- **ProviderUserId** (string): 第三方平台的用户 ID
- **ProviderUserName** (string, 可选): 第三方平台的用户名
- **AccessToken** (string, 可选): OAuth2 访问令牌（加密存储）
- **RefreshToken** (string, 可选): OAuth2 刷新令牌（加密存储）
- **CreatedAt** (DateTime): 绑定时间
- **唯一约束**: (Provider, ProviderUserId) 联合唯一

#### PasswordResetToken (密码重置令牌)
- **Id** (Guid, 主键): 令牌 ID
- **UserId** (long, 外键): 关联用户
- **Token** (string, 唯一): 重置令牌（哈希存储）
- **CreatedAt** (DateTime): 创建时间
- **ExpiresAt** (DateTime): 过期时间（24小时后）
- **IsUsed** (bool): 是否已使用

#### SecurityLog (安全日志)
- **Id** (long, 主键): 日志 ID
- **UserId** (long, 外键, 可选): 关联用户（登录失败时可能为空）
- **EventType** (enum): 事件类型（Login, Logout, PasswordChange, PasswordReset, FailedLogin, AccountLocked）
- **IpAddress** (string): 操作 IP 地址
- **UserAgent** (string): 浏览器信息
- **Success** (bool): 操作是否成功
- **Message** (string, 可选): 附加信息
- **CreatedAt** (DateTime): 事件时间

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: 用户可以在 60 秒内完成注册流程（从打开注册页面到成功登录）
- **SC-002**: 用户名可用性检查在 500 毫秒内返回结果
- **SC-003**: 登录请求在 1 秒内完成认证并返回令牌
- **SC-004**: 系统支持 1000 个并发登录请求不出现性能降级
- **SC-005**: 注册成功率达到 95% 以上（排除用户放弃的情况）
- **SC-006**: 密码重置邮件在 30 秒内发送
- **SC-007**: OAuth2 第三方登录流程在 10 秒内完成（包括第三方授权时间）
- **SC-008**: 暴力破解防护在 3 次失败后启用额外验证，5 次失败后锁定账户
- **SC-009**: 所有认证 API 必须在 2 秒内响应（99th percentile）
- **SC-010**: 用户可以在 30 秒内通过"忘记密码"功能发起密码重置
- **SC-011**: 会话管理界面加载在 1 秒内完成，显示所有活跃会话
- **SC-012**: 安全日志记录覆盖 100% 的认证相关操作

## Assumptions *(optional)*

### Technical Assumptions
- 系统默认使用 SQLite 数据库，支持通过配置切换到 PostgreSQL、SQL Server、MySQL
- JWT 令牌使用 HS256 算法签名（对称密钥），密钥存储在环境变量中
- 邮件发送使用 SMTP 协议，配置通过 appsettings.json 管理
- OAuth2 客户端密钥存储在环境变量或密钥管理服务中

### Business Assumptions
- 用户名唯一性在整个系统中全局唯一（不区分大小写）
- 密码最小长度 4 字符是为了兼容旧系统数据，新系统建议 8 字符以上
- 免费用户可以创建账户，无需付费或邀请码
- 用户数据保留期限遵守当地法律法规（如 GDPR）

### User Experience Assumptions
- 用户主要通过桌面浏览器访问，但必须支持移动端响应式设计
- 用户期望"记住我"功能在相同设备和浏览器上工作
- 第三方登录优先支持开发者常用的 GitHub 和 Google
- 用户不需要邮箱验证即可使用基本功能（邮箱验证在后续功能中可选）

## Dependencies *(optional)*

### Internal Dependencies
- 无（这是第一个功能，其他功能依赖此功能）

### External Dependencies
- **OAuth2 提供商**: GitHub OAuth App、Google OAuth 2.0、Microsoft Identity Platform
- **SMTP 服务**: 用于发送密码重置邮件（可使用 SendGrid, Mailgun, 或自建 SMTP）
- **数据库**: SQLite（默认）、PostgreSQL, SQL Server, MySQL（可选）

### Future Dependencies
- 用户资料系统将依赖此功能提供的 UserId
- 所有需要用户认证的功能（好友、私信、日志等）都依赖此功能

## Out of Scope *(optional)*

以下功能**不在**本次规格范围内，将在后续功能中实现：

- 用户资料完善（头像、昵称、个人简介等） - 属于"用户资料系统"
- 邮箱验证和手机号绑定 - 属于"用户资料系统"扩展功能
- 双因素认证（2FA / MFA） - 属于安全增强功能，P3 优先级
- 单点登录（SSO）企业集成 - 属于企业版功能
- 生物识别登录（指纹、人脸识别） - 属于移动应用功能
- 社交账号解绑功能 - 属于账户管理扩展功能
- 账户注销/删除功能 - 属于合规功能，后续实现
- 登录地点异常检测和通知 - 属于安全增强功能
- 验证码（CAPTCHA）防机器人 - 在实际出现滥用时再添加

## Notes *(optional)*

### Security Considerations
- JWT 令牌应使用 HTTPS 传输，避免令牌泄露
- 考虑使用 Refresh Token 机制提升安全性（短期 Access Token + 长期 Refresh Token）
- OAuth2 state 参数必须使用随机生成的值并在回调时验证
- 速率限制应基于 IP 和用户 ID 双重维度

### Performance Considerations
- 用户名可用性检查应使用数据库索引优化查询性能
- 密码哈希算法（bcrypt）计算成本较高，考虑使用缓存或异步处理
- JWT 令牌验证可以使用内存缓存减少数据库查询

### Scalability Considerations
- 会话数据可以迁移到 Redis 等缓存系统以支持水平扩展
- OAuth2 令牌存储应考虑加密和密钥轮换策略
- 安全日志可以异步写入，避免影响认证流程性能

### Open Questions for Future Iterations
- 是否需要支持 WebAuthn / FIDO2 无密码登录？
- 是否需要支持企业 SAML SSO 集成？
- 密码复杂度策略是否需要可配置（管理员设置）？
- 是否需要支持 "Login with Apple" 等其他提供商？
